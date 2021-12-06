using Album.Application.Application;
using Album.Application.Interface;
using Product.Application.Interface;
using Product.Domain.Aggregate;
using Product.Domain.BoundedContext;
using Product.Domain.Dto;
using Product.Domain.Entitys;
using Product.Infrastructure.MappingExtention;
using Product.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Application
{
    public class AProduct : IProduct
    {
        private readonly ProductQueries _productQueries = new ProductQueries();
        private readonly SpecificationsCategoryQueries _specificationsCategoryQueries = new SpecificationsCategoryQueries();
        private readonly FeatureProductQueries _featureProduct = new FeatureProductQueries();
        private readonly ImageProductQueries _imageProduct = new ImageProductQueries();
        private readonly HighlightProductQueries _highlightProduct = new HighlightProductQueries();
        private readonly IProductImage _productImage = new AProductImage();
        public List<string> AlbumProduct(int idSupplier)
        {
            return _productQueries.GetAllAlbum(idSupplier: idSupplier);
        }

        public async Task<bool> CheckIdProduct(int id)
        {
            return await _productQueries.CheckIdProduct(id);
        }

        public async Task<string> CreateProduct(CreateProductDtos createProductDtos, int supplier)
        {
            // get info  SpecificationsCategory theo category và null 
            var allSpecifications = await _specificationsCategoryQueries.GetAllCateryAndNullCategory(createProductDtos.ProductDto.CategoryProduct);

            // sử lý product căn bản 
            CheckProduct checkProduct = new CheckProduct();
            ProcessSpecifications processSpecifications = new ProcessSpecifications();

            checkProduct.CheckName(createProductDtos.ProductDto.Name);
            checkProduct.CheckName(createProductDtos.ProductDto.ProductAlbum);
            processSpecifications.CheckUnit(unit: createProductDtos.ProductDto.UnitProduct,
                                            specificationsCategorys: allSpecifications);
            processSpecifications.CheckUnit(unit: createProductDtos.ProductDto.Trademark,
                                            specificationsCategorys: allSpecifications,
                                            trademark: true);
            checkProduct.CheckOrigin(createProductDtos.ProductDto.Origin);
            checkProduct.CheckTag(createProductDtos.ProductDto.Tag);
            // lưu Product
            var product = await _productQueries.Create(new Domain.Entitys.Product
            {
                Name = createProductDtos.ProductDto.Name,
                UnitProduct = createProductDtos.ProductDto.UnitProduct,
                Fragile = createProductDtos.ProductDto.Fragile,
                Origin = createProductDtos.ProductDto.Origin,
                Trademark = createProductDtos.ProductDto.Trademark,
                Introduce = createProductDtos.ProductDto.Introduce,
                Tag = createProductDtos.ProductDto.Tag,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsStatus = 1,
                IsEnabled = true,
                Supplier = supplier,
                CategoryProduct = createProductDtos.ProductDto.CategoryProduct,
                ProductAlbum = createProductDtos.ProductDto.ProductAlbum,
                Seo = 1
            });

            // sử lý ảnh chia
            // chia cụm ảnh thành 3 dạng chính nhỏ vừa lớn
            // lưu thông tin ảnh
            var imageProducts = new Dictionary<string, int>();
            // sử lý ảnh Bìa
            // Lưu ảnh bìa gốc
            var imgRootCover = await _imageProduct.Create(new ImageProduct
            {
                Src = createProductDtos.ImageProductDtos[0].Url,
                Alt = createProductDtos.ProductDto.Name,
                Title = createProductDtos.ProductDto.Name,
                Size = "root",
                Folder = "rootImage",
                IsEnabled = true,
                IsCover = true,
                Product = product.Id
            });
            // sử lý ảnh gôc thành 220x220
            var imageCoverProcess = await _productImage.SaveUrlCover(url: createProductDtos.ImageProductDtos[0].Url);
            // tạo mới và lưu ảnh đã qua sử lý
            await _imageProduct.Create(new ImageProduct
            {
                Src = imageCoverProcess.Image220x220,
                Alt = createProductDtos.ProductDto.Name,
                Title = createProductDtos.ProductDto.Name,
                Size = "S220x220",
                Folder = "product",
                ImageRoot = imgRootCover.Id,
                IsEnabled = true,
                IsCover = true,
                Product = product.Id
            });
            imageProducts.Add(createProductDtos.ImageProductDtos[0].Url, imgRootCover.Id);

            // Sử lý ảnh phụ
            for (int i = 1; i < 9; i++)
            {
                if (!String.IsNullOrEmpty(createProductDtos.ImageProductDtos[i].Url))
                {
                    // lưu ảnh gốc
                    var imgRoot = await _imageProduct.Create(new ImageProduct
                    {
                        Src = createProductDtos.ImageProductDtos[i].Url,
                        Alt = createProductDtos.ProductDto.Name,
                        Title = createProductDtos.ProductDto.Name,
                        Size = "root",
                        Folder = "rootImage",
                        IsEnabled = true,
                        IsCover = false,
                        Product = product.Id
                    });
                    imageProducts.Add(createProductDtos.ImageProductDtos[i].Url, imgRoot.Id);
                    // sử lý ảnh Gốc thành các dạng 
                    var imageSupportProcess = await _productImage.SaveUrl(url: createProductDtos.ImageProductDtos[i].Url);
                    // tạo mới và lưu ảnh đã qua sử lý
                    await _imageProduct.Create(new ImageProduct
                    {
                        Src = imageSupportProcess.Image340x340,
                        Alt = createProductDtos.ProductDto.Name,
                        Title = createProductDtos.ProductDto.Name,
                        Size = "S340x340",
                        Folder = "product",
                        ImageRoot = imgRoot.Id,
                        IsEnabled = true,
                        IsCover = false,
                        Product = product.Id
                    });
                    await _imageProduct.Create(new ImageProduct
                    {
                        Src = imageSupportProcess.Image80x80,
                        Alt = createProductDtos.ProductDto.Name,
                        Title = createProductDtos.ProductDto.Name,
                        Size = "S80x80",
                        Folder = "product",
                        ImageRoot = imgRoot.Id,
                        IsEnabled = true,
                        IsCover = false,
                        Product = product.Id
                    });
                    await _imageProduct.Create(new ImageProduct
                    {
                        Src = imageSupportProcess.Image1360x1360,
                        Alt = createProductDtos.ProductDto.Name,
                        Title = createProductDtos.ProductDto.Name,
                        Size = "S1360x1360",
                        Folder = "product",
                        ImageRoot = imgRoot.Id,
                        IsEnabled = true,
                        IsCover = false,
                        Product = product.Id
                    });
                }
            }

            // sử lý tính năng sản phẩm
            var listFeatureProduct = new List<FeatureProduct>();
            foreach (var item in createProductDtos.FeatureProductDtos)
            {
                // check key và properties
                int key1 = processSpecifications.CheckKeyAndPropertiesSpecifications(key: item.Key1,
                                                                                     properties: item.Properties1,
                                                                                     specificationsCategorys: allSpecifications,
                                                                                     category: createProductDtos.ProductDto.CategoryProduct);

                int key2 = processSpecifications.CheckKeyAndPropertiesSpecifications(key: item.Key2,
                                                                                     properties: item.Properties2,
                                                                                     specificationsCategorys: allSpecifications,
                                                                                     category: createProductDtos.ProductDto.CategoryProduct);

                if (key1 != 0 && key2 != 0)
                {
                    listFeatureProduct.Add(await _featureProduct.Create(new FeatureProduct
                    {
                        Price = item.Price,
                        PriceMarket = item.PriceMarket,
                        TotalNumber = item.TotalNumber,
                        Key1 = key1,
                        Properties1 = item.Properties1,
                        Key2 = key2,
                        Properties2 = item.Properties2,
                        Vat = item.Vat,
                        Mass = item.Mass,
                        Volume = item.Volume,
                        Guarantee = item.Guarantee,
                        DateCreate = DateTime.Now,
                        DateUpdate = DateTime.Now,
                        IsDefault = false,
                        IsStatus = 0,
                        IsEnabled = true,
                        ImageProduct = String.IsNullOrEmpty(item.Image) ? default : imageProducts.FirstOrDefault(m => m.Key == item.Image).Value,
                        Product = product.Id
                    }));
                }
            }

            // thông số kỹ thuật
            foreach (var item in createProductDtos.HighlightProductDtos)
            {
                var specificationsForHighItem = processSpecifications.CheckKeyAndNameShowSpecifications(
                                                                      key: item.Key,
                                                                      nameShow: item.NameShow,
                                                                      specificationsCategorys: allSpecifications,
                                                                      category: createProductDtos.ProductDto.CategoryProduct);

                await _highlightProduct.Create(new HighlightProduct
                {
                    Key = specificationsForHighItem,
                    Values = item.Values,
                    DisplayOrder = item.DisplayOrder,
                    DateCreate = DateTime.Now,
                    DateUpdate = DateTime.Now,
                    IsStatus = 0,
                    Product = product.Id
                });
            }

            return "";
        }

        public async Task<UnitCardDtos> GetUnitProduct(int id)
        {
            //lấy thông tin căn bản của product

            var product = await _productQueries.GetUnitProduct(id: id);
            var allSpecifications = await _specificationsCategoryQueries.GetAllCateryAndNullCategory(product.CategoryProduct);
            var imageProduct = await _imageProduct.GetImageById(id: id);
            var featureProduct = await _featureProduct.GetFeatureProductById(id: id);
            var highlightProduct = await _highlightProduct.GetFeatureProductById(id: id);

            // map product to product card
            ProductCardDtos productCardDtos = new ProductCardDtos
            {
                Id = product.Id,
                Fragile = product.Fragile,
                Introduce = product.Introduce,
                Name = product.Name,
                Origin = product.Origin,
                Supplier = product.Supplier,
                Tag = product.Tag,
                Trademark = product.Trademark,
                NameUnitProduct = allSpecifications.FirstOrDefault(m => m.Id == product.UnitProduct).NameShow,
                NameTrademark = allSpecifications.FirstOrDefault(m => m.Id == product.Trademark).NameShow
            };

            // map image
            var imageCardDtos = imageProduct.Select(m => MappingData.InitializeAutomapper()
                                                                    .Map<ImageProductCardDtos>(m))
                                            .ToList();
            // feature Product
            var featureProductDtos = featureProduct.Select(m =>
                                                    new FeatureProductCardDtos
                                                    {
                                                        Id = m.Id,
                                                        Price = m.Price,
                                                        PriceMarket = m.PriceMarket,
                                                        TotalNumber = m.TotalNumber,
                                                        Key1 = m.Key1,
                                                        NameKey1 = allSpecifications.FirstOrDefault(n => n.Id == m.Key1).NameShow,
                                                        Properties1 = m.Properties1,
                                                        Key2 = m.Key2,
                                                        NameKey2 = allSpecifications.FirstOrDefault(n => n.Id == m.Key2).NameShow,
                                                        Properties2 = m.Properties2,
                                                        Vat = m.Vat,
                                                        Mass = m.Mass,
                                                        Volume = m.Volume,
                                                        Guarantee = m.Guarantee,
                                                        Image = m.ImageProduct
                                                    })
                .ToList();

            // map image
            var highlightProductCardDtos = highlightProduct.Select(m =>
                                                            new HighlightProductCardDtos
                                                            {
                                                                Id= m.Id,
                                                                Key = m.Key,
                                                                NameShow = allSpecifications.FirstOrDefault(n => n.Id == m.Key).NameShow,
                                                                DisplayOrder = m.DisplayOrder,
                                                                Product = m.Product,
                                                                Values = m.Values
                                                            })
                                                           .ToList();

            return new UnitCardDtos
            {
                productCardDtos = productCardDtos,
                imageProductCardDtos = imageCardDtos,
                featureProductCardDtos = featureProductDtos,
                highlightProductCardDtos = highlightProductCardDtos
            };
        }
    }
}
