import http from "../../services/httpService";
import {TokenSupplier} from './dto/tokenSupplier'
declare var abp: any;
class LCPermission {
  public async checkSupplier():Promise<String> {
    let rs = await http.post("/watch/check-supplier-load-page");
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async loginSupplier(password:string):Promise<TokenSupplier> {
    let rs = await http.get("/get/check-supplier-pass-page",{params:{password:password}});
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

}

export default new LCPermission();
