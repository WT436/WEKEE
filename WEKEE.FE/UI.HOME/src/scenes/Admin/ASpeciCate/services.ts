import { PagedListOutput } from "../../../services/dto/pagedListOutput";
import { SearchOrderPageInput } from "../../../services/dto/searchOrderPageInput";
import http from "../../../services/httpService";
import { SpecificationAttributeInsertDto } from "./dtos/SpecificationAttributeInsertDto";
import { SpecificationAttributeReadDto } from "./dtos/SpecificationAttributeReadDto";

class ASpeciCateService {

  //#region  GetPageListSpecificationService
  public async GetPageListSpecificationService(input: SearchOrderPageInput): Promise<PagedListOutput<SpecificationAttributeReadDto>> {
    let rs = await http.get('/specification-attribute', { params: input });
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
  //#endregion

  public async getCategoryMapService() {
    let rs = await http.get('/get-map-category');
    console.log(rs);
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }

  public async createSpecificationsStart(input: SpecificationAttributeInsertDto) {
    let rs = await http.post("/create-specification-attribute", input);
    console.log(rs);
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

}

export default new ASpeciCateService();
