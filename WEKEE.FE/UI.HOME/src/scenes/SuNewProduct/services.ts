import { Input } from "antd";
import http from "../../services/httpService";
import { CreateProductDtos } from "./dtos/createProductDtos";

class SuNewProductService {
  public async createProductStart(createProductDtos: CreateProductDtos) {
    console.log(createProductDtos);
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
    let rs = await http.post("/list/get-album-product");
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getCategotyMainStart() {
    let rs = await http.get("/list/get-data-category");
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async authenticate() {
    let rs = await http.post("/get/log-in");
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }
}

export default new SuNewProductService();
