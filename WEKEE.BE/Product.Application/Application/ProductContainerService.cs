using Product.Application.Interface;
using Product.Domain.Shared.DataTransfer.ProductDTO;
using Product.Domain.Shared.Entitys;
using Product.Infrastructure.EventBus;
using Product.Infrastructure.MappingExtention;
using Product.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Any;

namespace Product.Application.Application
{
    public class ProductContainerService : IProductContainer
    {
        private readonly ProductQuery _productQuery = new ProductQuery();
        private readonly ProductProductTagMappingQuery _productProductTagMappingQuery = new ProductProductTagMappingQuery();
        private readonly SeoProductQuery _seoProductQuery = new SeoProductQuery();
        private readonly ProductCategoryMappingQuery _productCategoryMappingQuery = new ProductCategoryMappingQuery();
        private readonly SpecificationAttributeMappingQuery _specificationAttributeMappingQuery = new SpecificationAttributeMappingQuery();
        private readonly ImageProcessBus _imageProcess = new ImageProcessBus();
        private readonly ImageProductQuery _image = new ImageProductQuery();
        private readonly ProductPictureQuery _productPictureQuery = new ProductPictureQuery();
        private readonly FeatureProductQuery _featureProductQuery = new FeatureProductQuery();
        private readonly ProductAttributeValueQuery _productAttributeValueQuery = new ProductAttributeValueQuery();
        private readonly ProductAttributeMappingQuery _productAttributeMappingQuery = new ProductAttributeMappingQuery();

        // currently only add data with standard input data. have not checked the data, adding failed....
        public async Task<bool> ProcessProductContainer(ProductContainerInsertDto input, int idAccount)
        {
            // add product
            var product = MappingData.InitializeAutomapper().Map<Domain.Shared.Entitys.Product>(input.ProductInsertDto);
            product.CreateBy = idAccount;
            _productQuery.Insert(product);
            string nameSeo = LanguageConvert.ConvertVietNamese(product.Name);
            // add product tag
            //var dataProductTag = input.ProductTagDtos.ToList().Select(m => new ProductProductTagMapping
            //{
            //    ProductId = product.Id,
            //    ProductTagId = m,
            //    CreateBy = idAccount
            //}).ToList();

            //_productProductTagMappingQuery.Insert(dataProductTag);
            //// add seo
            _seoProductQuery.Insert(new Seo { });
            // add category
            int iProductCategory = 0;
            var dataProductCategory = input.CategoryProduct.IdCategory
                                      .ToList().Select(m => new ProductCategoryMapping
                                      {
                                          ProductId = product.Id,
                                          CategoryId = m,
                                          CreateBy = idAccount,
                                          IsFeaturedProduct = m == input.CategoryProduct.CategoryMain,
                                          DisplayOrder = (++iProductCategory)
                                      }).ToList();

            _productCategoryMappingQuery.Insert(dataProductCategory);
            // add Specification
            int iSpecification = 0;
            var dataProductSpecification = input.SpecificationProductDtos
                                                .ToList().Select(m => new ProductSpecificationAttributeMapping
                                                {
                                                    ProductId = product.Id,
                                                    SpecificationId = m.SpecificationId,
                                                    CustomValue = m.CustomValue,
                                                    AttributeTypeId = m.AttributeTypeId,
                                                    CreateBy = idAccount,
                                                    AllowFiltering = m.AllowFiltering,
                                                    ShowOnProductPage = true,
                                                    DisplayOrder = (++iSpecification)
                                                }).ToList();
            _specificationAttributeMappingQuery.Insert(dataProductSpecification);

            // add image product
            var dataImage = await _imageProcess.ImageProcessRabbitMQ(input.ImageRoot);

            // add image to image product
            List<ImageProduct> imageProducts = new List<ImageProduct>();

            int iImageProduct = 0;

            if (dataImage.Count > 0)
            {
                foreach (var imageItem in dataImage)
                {
                    iImageProduct++;
                    List<ImageProduct> imageProductsItem = new List<ImageProduct>();
                    var imageRoot = _image.InsertImageProductOutId(new ImageProduct
                    {
                        IsCover = false,
                        MimeType = "image/*",
                        SeoFilename = nameSeo,
                        AltAttribute = product.Name,
                        TitleAttribute = product.Name,
                        IsNew = true,
                        VirtualPath = imageItem.ImageNameRoot,
                        Size = "x",
                        Folder = "product"
                    });

                    imageProductsItem.Add(new ImageProduct
                    {
                        IsCover = false,
                        MimeType = "image/*",
                        SeoFilename = nameSeo,
                        AltAttribute = product.Name,
                        TitleAttribute = product.Name,
                        IsNew = true,
                        VirtualPath = imageItem.ImageNameSizeS120x120,
                        Size = "S120x120",
                        Folder = "product",
                        ImageRoot = imageRoot
                    });
                    imageProductsItem.Add(new ImageProduct
                    {
                        IsCover = false,
                        MimeType = "image/*",
                        SeoFilename = nameSeo,
                        AltAttribute = product.Name,
                        TitleAttribute = product.Name,
                        IsNew = true,
                        VirtualPath = imageItem.ImageNameSizeS1360x540,
                        Size = "S1360x540",
                        Folder = "product",
                        ImageRoot = imageRoot
                    });
                    imageProductsItem.Add(new ImageProduct
                    {
                        IsCover = false,
                        MimeType = "image/*",
                        SeoFilename = nameSeo,
                        AltAttribute = product.Name,
                        TitleAttribute = product.Name,
                        IsNew = true,
                        VirtualPath = imageItem.ImageNameSizeS180x180,
                        Size = "S180x180",
                        Folder = "product",
                        ImageRoot = imageRoot
                    });
                    imageProductsItem.Add(new ImageProduct
                    {
                        IsCover = false,
                        MimeType = "image/*",
                        SeoFilename = nameSeo,
                        AltAttribute = product.Name,
                        TitleAttribute = product.Name,
                        IsNew = true,
                        VirtualPath = imageItem.ImageNameSizeS80x80,
                        Size = "S80x80",
                        Folder = "product",
                        ImageRoot = imageRoot
                    });
                    imageProductsItem.Add(new ImageProduct
                    {
                        IsCover = true,
                        MimeType = "image/*",
                        SeoFilename = nameSeo,
                        AltAttribute = product.Name,
                        TitleAttribute = product.Name,
                        IsNew = true,
                        VirtualPath = imageItem.ImageNameSizeS220x220,
                        Size = "S220x220",
                        Folder = "product",
                        ImageRoot = imageRoot
                    });
                    imageProductsItem.Add(new ImageProduct
                    {
                        IsCover = false,
                        MimeType = "image/*",
                        SeoFilename = nameSeo,
                        AltAttribute = product.Name,
                        TitleAttribute = product.Name,
                        IsNew = true,
                        VirtualPath = imageItem.ImageNameSizeS340x340,
                        Size = "S340x340",
                        Folder = "product",
                        ImageRoot = imageRoot
                    });

                    _image.InsertImageProductOutId(imageProductsItem);

                    List<ProductPictureMapping> productPictureMappings = new List<ProductPictureMapping>();

                    if (imageProductsItem.Count > 0)
                    {
                        foreach (var itemProdutImageMapping in imageProductsItem)
                        {
                            productPictureMappings.Add(new ProductPictureMapping
                            {
                                PictureId = itemProdutImageMapping.Id,
                                ProductId = product.Id,
                                DisplayOrder = iImageProduct,
                                IsDelete = false,
                                CreateBy = idAccount
                            });
                        }
                    }

                    _productPictureQuery.Insert(productPictureMappings);

                    imageProducts.AddRange(imageProductsItem);
                }
            }

            // add feature product
            if (input.FeatureProductInsertDtos.Count > 0)
            {
                List<FeatureProduct> featureProducts = new List<FeatureProduct>();
                foreach (var itemFeature in input.FeatureProductInsertDtos)
                {
                    // insert feature
                    var dataFeatureProductQuery = _featureProductQuery.Insert(new FeatureProduct
                    {
                        ProductId = product.Id,
                        WeightAdjustment = itemFeature.WeightAdjustment,
                        LengthAdjustment = itemFeature.LengthAdjustment,
                        WidthAdjustment = itemFeature.WidthAdjustment,
                        HeightAdjustment = itemFeature.HeightAdjustment,
                        Price = itemFeature.Price,
                        Quantity = itemFeature.Quantity,
                        DisplayOrder = itemFeature.DisplayOrder,
                        MainProduct = itemFeature.MainProduct,
                        PictureId = (int)imageProducts.Where(n => n.Size == "S220x220"
                                                          && n.VirtualPath == (dataImage.Where(m => m.NameUpload == itemFeature.PictureString)
                                                                                        .FirstOrDefault().ImageNameSizeS220x220))
                                                  .FirstOrDefault().ImageRoot,
                        CreateBy = idAccount
                    });

                    // insert product atri value
                    List<ProductAttributeValue> productAttributeValues = new List<ProductAttributeValue>();
                    if (itemFeature.ProductAttributeValueInsertDtos.Count > 0)
                    {
                        foreach (var itemProAttVa in itemFeature.ProductAttributeValueInsertDtos)
                        {
                            productAttributeValues.Add(new ProductAttributeValue
                            {
                                Key = itemProAttVa.Key,
                                Values = itemProAttVa.Values,
                                IsDelete = false,
                                CreateBy = idAccount
                            });
                        }
                    }

                    _productAttributeValueQuery.Insert(productAttributeValues);
                    // insert atri mapp
                    if (productAttributeValues.Count > 0)
                    {
                        List<ProductAttributeMapping> _productAttributeMappings = new List<ProductAttributeMapping>();
                        foreach (var itemAttrMap in productAttributeValues)
                        {
                            _productAttributeMappings.Add(new ProductAttributeMapping
                            {
                                FeatureProductId = dataFeatureProductQuery,
                                ProductAttributeValuesId = itemAttrMap.Id,
                                CreateBy = idAccount
                            });
                        }

                        // add atribute mapping
                        _productAttributeMappingQuery.Insert(_productAttributeMappings);
                    }
                }
            }

            return false;
        }
    }
}
