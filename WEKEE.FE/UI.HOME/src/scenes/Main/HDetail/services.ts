import http from "../../../services/httpService";

class HDetailService {
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
}

export default new HDetailService();
