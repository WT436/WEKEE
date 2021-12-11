using Album.Application.Application;
using Album.Application.Interface;
using Assessment.Application.Interface;
using Assessment.Domain.Dto;
using Assessment.Domain.Entitys;
using Assessment.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UnitOfWork.Collections;
using Utils.Exceptions;

namespace Assessment.Application.Application
{
    public class AEvaluates : IEvaluates
    {
        private readonly EvaluatesProductQuery _evaluatesProductQuery = new EvaluatesProductQuery();
        private readonly ImageEvaluatesProductQuery _imageEvaluatesProduct = new ImageEvaluatesProductQuery();
        private readonly LikeEvaluatesProductQuery _likeEvaluatesProductQuery = new LikeEvaluatesProductQuery();
        private readonly IProductImage _productImage = new AProductImage();

        public async Task<string> CreateEvaluates(EvaluatesProductDto evaluatesProductDto)
        {
            // check thông số
            if (evaluatesProductDto.StarNumber > 5 || evaluatesProductDto.StarNumber < 1)
            {
                throw new ClientException(400, "You need select star number!");
            }
            // add 
            var data = _evaluatesProductQuery.Create(new EvaluatesProduct
            {
                Content = evaluatesProductDto.Content,
                StarNumber = evaluatesProductDto.StarNumber,
                PinFeeling = JsonSerializer.Serialize(evaluatesProductDto.PinFeeling),
                TagAccount = null,
                LevelEvaluates = 0,
                IdEvaluatesProduct = null,
                Product = evaluatesProductDto.Product,
                Account = evaluatesProductDto.Account,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });
            // add image
            if (evaluatesProductDto.Image.Count != 0)
            {
                List<ImageEvaluatesProduct> imageEvaluatesProducts = new List<ImageEvaluatesProduct>();
                for (int i = 0; i < evaluatesProductDto.Image.Count; i++)
                {
                    var url = evaluatesProductDto.Image[i].Replace("\\", "/");
                    // add image root
                    ImageEvaluatesProduct imageEvaluatesProduct = _imageEvaluatesProduct.InsertImageUnit(new ImageEvaluatesProduct
                    {
                        Src = url,
                        Alt = "User comment",
                        Title = "User comment",
                        Size = "Root",
                        Folder = "rootImage",
                        TypesImage = false,
                        IdEvaluatesProduct = data.Id,
                        IsEnabled = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // sử lý image 80x80 và 340x340
                    var imageProcessSupport = await _productImage.SaveUrl80And340(url);

                    imageEvaluatesProducts.Add(new ImageEvaluatesProduct
                    {
                        Src = imageProcessSupport.Image80x80,
                        Alt = "User comment",
                        Title = "User comment",
                        Size = "S80x80",
                        Folder = "product",
                        ImageRoot = imageEvaluatesProduct.Id,
                        TypesImage = false,
                        IdEvaluatesProduct = data.Id,
                        IsEnabled = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });
                    imageEvaluatesProducts.Add(new ImageEvaluatesProduct
                    {
                        Src = imageProcessSupport.Image340x340,
                        Alt = "User comment",
                        Title = "User comment",
                        Size = "S340x340",
                        Folder = "product",
                        ImageRoot = imageEvaluatesProduct.Id,
                        TypesImage = false,
                        IdEvaluatesProduct = data.Id,
                        IsEnabled = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });
                };
                _imageEvaluatesProduct.InsertImageMultiple(imageEvaluatesProducts);
            }
            return null;
        }

        public async Task<GetEvaluatesProductDto> OverviewEvaluatesProduct(int id)
        {
            GetEvaluatesProductDto getEvaluatesProductDto = new GetEvaluatesProductDto();
            // get start number
            getEvaluatesProductDto.NumberStarOne = await _evaluatesProductQuery.SumStart(id, 1);
            getEvaluatesProductDto.NumberStarTwo = await _evaluatesProductQuery.SumStart(id, 2);
            getEvaluatesProductDto.NumberStarThree = await _evaluatesProductQuery.SumStart(id, 3);
            getEvaluatesProductDto.NumberStarFour = await _evaluatesProductQuery.SumStart(id, 4);
            getEvaluatesProductDto.NumberStarFive = await _evaluatesProductQuery.SumStart(id, 5);
            // get image
            var dataEvaluatesImage = _imageEvaluatesProduct.GetAllImageEvaluatesProduct(id);
            List<ImageEvaluatesDtos> imageEvaluatesDtos = new List<ImageEvaluatesDtos>();
            var itemS80x80 = dataEvaluatesImage.Where(m => m.Size == "S80x80").Select(n => new { n.Src, n.ImageRoot }).ToList();
            var itemS340x340 = dataEvaluatesImage.Where(m => m.Size == "S340x340").Select(n => new { n.Src, n.ImageRoot }).ToList();
            itemS80x80.ForEach(item =>
            {
                foreach (var item2 in itemS340x340)
                {
                    if (item.ImageRoot == item2.ImageRoot)
                    {
                        imageEvaluatesDtos.Add(new ImageEvaluatesDtos { Image80x80 = item.Src, Image340x340 = item2.Src });
                        break;
                    }
                };
            });
            getEvaluatesProductDto.ImageReview = imageEvaluatesDtos;
            return getEvaluatesProductDto;
        }

        public async Task<List<ReviewEvaluatesOutputDto>> GetReviewEvaluatesProduct(ReviewEvaluatesInputDto reviewEvaluatesInputDto,
                                                                                                        int account)
        {
            // tong hop danh gia
            IList<EvaluatesProduct> dataEvaluatesProduct = new List<EvaluatesProduct>();
            if (reviewEvaluatesInputDto.Proviso == null || reviewEvaluatesInputDto.Proviso.Count() == 0)
            {
                var data = await _evaluatesProductQuery.GetPageListEvaluatesProduct(
                                                  product: reviewEvaluatesInputDto.Id,
                                                     page: reviewEvaluatesInputDto.Page);
                dataEvaluatesProduct = data.Items;
            }
            else
            {
                int[] starSelect = new int[5] { 0, 0, 0, 0, 0 };
                reviewEvaluatesInputDto.Proviso.ForEach(m =>
                {
                    if (m >= 1 && m <= 5)
                    {
                        starSelect[m - 1] = m;
                    }
                });

                var data = await _evaluatesProductQuery.GetPageListEvaluatesProduct(
                                                                             product: reviewEvaluatesInputDto.Id,
                                                                                page: reviewEvaluatesInputDto.Page,
                                                                                star: starSelect);
                dataEvaluatesProduct = data.Items;
            }

            // dữ liệu trả về 
            List<ReviewEvaluatesOutputDto> reviewEvaluatesOutputDtos = new List<ReviewEvaluatesOutputDto>();

            foreach (EvaluatesProduct item in dataEvaluatesProduct.ToList())
            {
                reviewEvaluatesOutputDtos.Add(await MapDataEvaluatesProduct(item, account));
            };

            return reviewEvaluatesOutputDtos;
        }
        private async Task<ReviewEvaluatesOutputDto> MapDataEvaluatesProduct(EvaluatesProduct item, int account)
        {
            var dataEvaluatesImage = await _imageEvaluatesProduct.GetAllImageUserReview(evaluates: item.Id);
            List<ImageEvaluatesDtos> imageEvaluatesDtos = new List<ImageEvaluatesDtos>();
            var itemS80x80 = dataEvaluatesImage.Where(m => m.Size == "S80x80").Select(n => new { n.Src, n.ImageRoot }).ToList();
            var itemS340x340 = dataEvaluatesImage.Where(m => m.Size == "S340x340").Select(n => new { n.Src, n.ImageRoot }).ToList();
            itemS80x80.ForEach(item =>
            {
                foreach (var item2 in itemS340x340)
                {
                    if (item.ImageRoot == item2.ImageRoot)
                    {
                        imageEvaluatesDtos.Add(new ImageEvaluatesDtos { Image80x80 = item.Src, Image340x340 = item2.Src });
                        break;
                    }
                };
            });

            ReviewEvaluatesOutputDto reviewEvaluatesOutputDto = new ReviewEvaluatesOutputDto
            {
                // thong tin user
                AccountReview = await SyntheticEvaluatesForAccount(account: item.Account),
                // thong tin phan hoi 
                IdReview = item.Id,
                Content = item.Content,
                StarNumber = (int)item.StarNumber,
                PinFeeling = item.PinFeeling,
                DateReview = item.UpdatedAt,
                LikeReview = await _likeEvaluatesProductQuery.CountIsLikeEvaluates(item.Id),
                DislikeReview = await _likeEvaluatesProductQuery.CountIsDisLikeEvaluates(item.Id),
                CommentReview = await _evaluatesProductQuery.GetNumberRepReviewProduct(id: item.Id,
                                                                                  product: item.Product,
                                                                                  levelEvaluates: 0),
                // image
                Image = imageEvaluatesDtos,
                //  you and comment
                YouLike = await _likeEvaluatesProductQuery.CheckYouLikeEvaluatesProduct(levelEvaluates: 0,
                                                                                           idEvaluates: item.Id,
                                                                                               account: account,
                                                                                                islike: true),
                YouDisLike = await _likeEvaluatesProductQuery.CheckYouLikeEvaluatesProduct(levelEvaluates: 0,
                                                                                              idEvaluates: item.Id,
                                                                                                  account: account,
                                                                                                   islike: false),
                // rep comment get one record
                RepCommentEvaluates = await RepCommentEvaluatesOutputDto(id: item.Id, account: account, level: 1, page: -1)

            };

            return reviewEvaluatesOutputDto;
        }

        private async Task<ReviewAccountEvaluatesOutputDto> SyntheticEvaluatesForAccount(int account)
        {
            return new ReviewAccountEvaluatesOutputDto
            {
                Id = account,
                UserEvaluates = await _evaluatesProductQuery.GetNumberReviewProduct(account),
                UserRepEvaluates = await _evaluatesProductQuery.GetNumberReplyReviewProduct(account),
                UserGetFavorites = await _likeEvaluatesProductQuery.CountIsLikeAccountEvaluates(account),
                UserGetObjections = await _likeEvaluatesProductQuery.CountIsDisLikeAccountEvaluates(account)
            };
        }

        private async Task<List<RepCommentEvaluatesOutputDto>> RepCommentEvaluatesOutputDto(int id, int account, int level, int page)
        {
            List<EvaluatesProduct> evaluatesProducts = new List<EvaluatesProduct>();
            if (page == -1)
            {
                evaluatesProducts.Add(await _evaluatesProductQuery.GetUnitEvaluatesProduct(idEvaluatesProduct: id));
            }
            else
            {
                evaluatesProducts = await _evaluatesProductQuery.GetPageListRepEvaluatesProduct(level: level, idEvaluatesProduct: id, page: page);
            }

            var datareturn = new List<RepCommentEvaluatesOutputDto>();

            foreach (var data in evaluatesProducts)
            {
                if (data == null)
                {
                    return new List<RepCommentEvaluatesOutputDto>();
                }
                else
                {
                    datareturn.Add(new RepCommentEvaluatesOutputDto
                    {
                        Id = data.Id,
                        IdAccount = data.Account,
                        AvatarAccount = "",
                        NameAccount = "",
                        Comment = data.Content,
                        NumberLike = await _likeEvaluatesProductQuery.CountIsLikeEvaluates(data.Id),
                        NumberDisLike = await _likeEvaluatesProductQuery.CountIsDisLikeEvaluates(data.Id),
                        NumberComment = await _evaluatesProductQuery.GetNumberRepReviewProduct(id: data.Id,
                                                                                          product: data.Product,
                                                                                   levelEvaluates: level),
                        NumberRepost = 0,
                        DateComment = data.CreatedAt,
                        YouLike = await _likeEvaluatesProductQuery.CheckYouLikeEvaluatesProduct(levelEvaluates: level,
                                                                                                   idEvaluates: data.Id,
                                                                                                       account: account,
                                                                                                        islike: true),
                        YouDisLike = await _likeEvaluatesProductQuery.CheckYouLikeEvaluatesProduct(levelEvaluates: level,
                                                                                                   idEvaluates: data.Id,
                                                                                                       account: account,
                                                                                                        islike: false),
                        RepCommentEvaluates = new List<RepCommentEvaluatesOutputDto>()
                    });
                }
            }
            return datareturn;
        }

        public async Task<string> CreateRepEvaluates(EvaluatesProductDto evaluatesProductDto)
        {
            // check id
            if (!await _evaluatesProductQuery.CheckIdEvaluatesProduct(evaluatesProductDto.Id))
            {
                throw new ClientException(400, "Comment does not exist!");
            }
            // add 
            var data = _evaluatesProductQuery.Create(new EvaluatesProduct
            {
                Content = evaluatesProductDto.Content,
                StarNumber = null,
                PinFeeling = null,
                TagAccount = null,
                LevelEvaluates = evaluatesProductDto.LevelEvaluates,
                IdEvaluatesProduct = evaluatesProductDto.Id,
                Product = evaluatesProductDto.Product,
                Account = evaluatesProductDto.Account,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });
            // add image
            if (evaluatesProductDto.Image.Count != 0)
            {
                List<ImageEvaluatesProduct> imageEvaluatesProducts = new List<ImageEvaluatesProduct>();
                for (int i = 0; i < evaluatesProductDto.Image.Count; i++)
                {
                    var url = evaluatesProductDto.Image[i].Replace("\\", "/");
                    // add image root
                    ImageEvaluatesProduct imageEvaluatesProduct = _imageEvaluatesProduct.InsertImageUnit(new ImageEvaluatesProduct
                    {
                        Src = url,
                        Alt = "User comment",
                        Title = "User comment",
                        Size = "Root",
                        Folder = "rootImage",
                        TypesImage = false,
                        IdEvaluatesProduct = data.Id,
                        IsEnabled = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // sử lý image 80x80 và 340x340
                    var imageProcessSupport = await _productImage.SaveUrl80And340(url);

                    imageEvaluatesProducts.Add(new ImageEvaluatesProduct
                    {
                        Src = imageProcessSupport.Image80x80,
                        Alt = "User comment",
                        Title = "User comment",
                        Size = "S80x80",
                        Folder = "product",
                        ImageRoot = imageEvaluatesProduct.Id,
                        TypesImage = false,
                        IdEvaluatesProduct = data.Id,
                        IsEnabled = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });
                    imageEvaluatesProducts.Add(new ImageEvaluatesProduct
                    {
                        Src = imageProcessSupport.Image340x340,
                        Alt = "User comment",
                        Title = "User comment",
                        Size = "S340x340",
                        Folder = "product",
                        ImageRoot = imageEvaluatesProduct.Id,
                        TypesImage = false,
                        IdEvaluatesProduct = data.Id,
                        IsEnabled = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });
                };
                _imageEvaluatesProduct.InsertImageMultiple(imageEvaluatesProducts);
            }
            return null;
        }

        public async Task<List<RepCommentEvaluatesOutputDto>> GetDataReply(int id, int account, int level, int page)
        {
            if (!await _evaluatesProductQuery.CheckIdEvaluatesProduct(id: id))
            {
                throw new ClientException(400, "Commnet does not exist!");
            }

            return await RepCommentEvaluatesOutputDto(id: id, account: account, level: level, page: page);
        }
    }
}
