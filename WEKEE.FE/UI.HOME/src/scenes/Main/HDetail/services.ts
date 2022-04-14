import http from "../../../services/httpService";
import { CartBasicProductDto } from "./dtos/cartBasicProductDto";

class HDetailService {

  //#region  getBasicProductCart
  public async getBasicProductCartService(input: number): Promise<CartBasicProductDto> {
    let rs = await http.get('/cart-basic-product', { params: { input: input } });
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
  //#endregion
  //#region GET_CATEGORY_BREADCRUMB 
  public async getCategoryBreadcrumbStart(input: number) {
    let rs = await http.get("/get-data-category-becrum", {
      params: { input: input },
    });
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }
  //#endregion
}

export default new HDetailService();
