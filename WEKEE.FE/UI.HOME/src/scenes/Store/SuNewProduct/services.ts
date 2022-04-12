import http from "../../../services/httpService";
import { CreateProductDtos } from "./dtos/createProductDtos";
import { ProductAttributeReadTypesDto } from "./dtos/productAttributeReadTypesDto";
import { ProductAttributeValueReadDto } from "./dtos/productAttributeValueReadDto";
import { ProductContainerInsertDto } from "./dtos/productContainerInsertDto";

class SuNewProductService {
  //#region  loadKeyGroupService
  public async loadKeyGroupService(input: number[], nameGroup: string | undefined): Promise<string[]> {
    let rs = await http.get('/load-specification-data',
      {
        params: {
          category: input,
          nameGroup: nameGroup
        }
      });
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
  //#endregion
  //#region  nameGroupSpecService
  public async nameGroupSpecService(input: number[]): Promise<string[]> {
    let rs = await http.get('/load-name-group-spec', { params: { input: input } });
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
  //#endregion

  //#region  loadCategoryValueService
  public async loadCategoryValueService(input: number): Promise<ProductAttributeValueReadDto[]> {
    let rs = await http.get('/load-values-attribute', { params: { input: input } });
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
  //#endregion
  //#region  InsertProductFullService
  public async InsertProductFullService(input: ProductContainerInsertDto): Promise<boolean> {
    let rs = await http.post('/create-product', input);
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
  //#endregion

  //#region  proAttrTypesUnitService
  public async proAttrTypesUnitService(input: number, categorys: number[]): Promise<ProductAttributeReadTypesDto[]> {
    let rs = await http.get('/product-attribute-type-one', { params: { input: input, categorys: categorys } });
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
  //#endregion

  public async createProductStart(createProductDtos: CreateProductDtos) {
    let rs = await http.post("/create/create-product", createProductDtos);
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getSpecifiCategoryUnitStart() {
    let rs = await http.get("/get/get-key-specifications-category");
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getSpecifiCategoryStart(input: number) {
    let rs = await http.get(
      "/get/get-classify-values-specifications-category",
      { params: { category: input } }
    );
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async readFullAlbumProductStart() {
    let rs = await http.get("/get-all-product-album");
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getCategotyMainStart() {
    let rs = await http.get('/get-map-category');
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
}

export default new SuNewProductService();
