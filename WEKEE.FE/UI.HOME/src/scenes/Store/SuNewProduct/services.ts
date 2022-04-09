import http from "../../../services/httpService";
import { CreateProductDtos } from "./dtos/createProductDtos";
import { ProductAttributeReadTypesDto } from "./dtos/productAttributeReadTypesDto";
import { ProductContainerInsertDto } from "./dtos/productContainerInsertDto";

class SuNewProductService {

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
  public async proAttrTypesUnitService(input: number): Promise<ProductAttributeReadTypesDto[]> {
    let rs = await http.get('/product-attribute-type-one', { params: { input: input } });
    console.log(rs)
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
    console.log(rs.data);
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getCategotyMainStart() {
    let rs = await http.get('/get-map-category');
    console.log(rs)
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
}

export default new SuNewProductService();
