import { AuthenticationInput } from "./dtos/authenticationInput";
import { AuthenticationResult } from "./dtos/authenticationResult";
import http from "../../../services/httpService";
declare var abp: any;
class LoginService {
  public async authenticate(input: AuthenticationInput): Promise<AuthenticationResult | String> {
    let rs = await http.post("/UserAccount/LoginAccount", input);
    if (rs) {
      return rs.data;
    }
    else {
      return rs;
    }
  }
}

export default new LoginService();
