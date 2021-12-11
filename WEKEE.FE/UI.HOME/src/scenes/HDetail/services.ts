import http from "../../services/httpService";
import { EvaluatesProductDto } from "./dtos/evaluatesProductDto";
import { ReviewEvaluatesInputDto } from "./dtos/reviewEvaluatesInputDto";

class HDetailService {
  public async getRepcommentAssessmentStart(
    id: number,
    level: number,
    page: number
  ) {
    let rs = await http.get("/list/repevaluates-product", {
      params: { id: id, level: level, page: page },
    });

    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }
  public async repcommentAssessmentStart(
    evaluatesProductDto: EvaluatesProductDto
  ) {
    let rs = await http.post(
      "/create/repevaluates-product",
      evaluatesProductDto
    );
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }
  public async dislikeEvaluatesProductStart(
    levelEvaluates: number,
    idEvaluates: number
  ) {
    let rs = await http.get("/edit/dislike-evaluates", {
      params: { levelEvaluates: levelEvaluates, idEvaluates: idEvaluates },
    });
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }
  public async likeEvaluatesProductStart(
    levelEvaluates: number,
    idEvaluates: number
  ) {
    let rs = await http.get("/edit/like-evaluates", {
      params: { levelEvaluates: levelEvaluates, idEvaluates: idEvaluates },
    });
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async reviewEvaluatesProductStart(
    reviewEvaluatesInputDto: ReviewEvaluatesInputDto
  ) {
    let rs = await http.post(
      "/list/overview-evaluates-product",
      reviewEvaluatesInputDto
    );
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }
  public async overviewEvaluatesProductStart(id: number) {
    let rs = await http.get("/get/overview-evaluates-product", {
      params: { id: id },
    });
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }
  public async createYouAssessmentStart(
    evaluatesProductDto: EvaluatesProductDto
  ) {
    let rs = await http.post("/create/evaluates-product", evaluatesProductDto);
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async removeYouAssessmentStart(url: string) {
    let rs = await http.delete("/delete/image-evaluates", {
      params: { url: url },
    });
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getProductCardStart(input: number) {
    let rs = await http.get("/list/get-data-product", {
      params: { id: input },
    });
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getCategoryBreadcrumbStart(input: number) {
    let rs = await http.get("/watch/get-data-category", {
      params: { id: input },
    });
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }
}

export default new HDetailService();
