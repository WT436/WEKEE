import { AuthenticationInput } from "./dtos/authenticationInput";
import { AuthenticationResult } from "./dtos/authenticationResult";
import http from "../../../services/httpService";
declare var abp: any;
class LoginService {
  public async authenticate(
    input: AuthenticationInput
  ): Promise<AuthenticationResult> {
    console.log(input)
    let rs = await http.post("/UserAccount/LoginAccount",input);
    if (rs) {
      return rs.data;
    } else {
      return rs;
    }
  }

  public async getIp() {
    let rs = await http.get("https://geoip-db.com/json/");
    if (rs) {
      if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
          rs.data.latitude = position.coords.latitude;
          rs.data.longitude = position.coords.longitude;
        });
      }
      return rs.data;
    } else {
      return rs;
    }
  }
}

export default new LoginService();
