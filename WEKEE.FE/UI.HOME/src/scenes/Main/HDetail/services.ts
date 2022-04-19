import http from "../../../services/httpService";
import { CartBasicProductDto } from "./dtos/cartBasicProductDto";
import { FeatureProductContainerDto } from "./dtos/featureProductContainerDto";
import { ImageForProductDto } from "./dtos/imageForProductDto";

class HDetailService {
  //#region  getFeatureCartProductService
  public async getFeatureCartProductService(input: number): Promise<FeatureProductContainerDto[]> {
    let rs = await http.get('/cart-feature-product', { params: { input: input } });
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
  //#endregion
  //#region  getImageProductService
  public async getImageProductService(input: number): Promise<ImageForProductDto[]> {
    let rs = await http.get('/cart-image-product', { params: { input: input } });
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
  //#endregion
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
