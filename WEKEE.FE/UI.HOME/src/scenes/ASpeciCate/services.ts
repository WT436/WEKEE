import http from "../../services/httpService";
import { SpecificationsCategoryDto } from "./dtos/specificationsCategoryDto";

class ASpeciCateService {
  public async searchSpecificationsStart(key: string, value: string) {
    let rs = await http.get("/get/create-specifications-category", {
      params: { key: key, values: value },
    });
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getNameClassifyValuesSpecificationsStart(input: string) {
    let rs = await http.get(
      "/list/get-classify-values-specifications-category",
      { params: { key: input } }
    );
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getNameKeySpecificationsStart() {
    let rs = await http.get("/list/get-key-specifications-category");
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async createSpecificationsStart(input: SpecificationsCategoryDto) {
    let rs = await http.post("/create/create-specifications-category", input);
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

export default new ASpeciCateService();
