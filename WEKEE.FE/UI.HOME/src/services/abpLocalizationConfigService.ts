import { L } from '../lib/abpUtility';
import enJson from '../localization/en.json';

declare var abp: any;

class AbpLocalizationConfigService {
  public async getLocalization() {
    let language;
    if (!abp.utils.getCookieValue('_language')) {
      language = "en";
    }
    else {
      language = abp.utils.getCookieValue('_language');
    }

    let objReturn;
    switch(language) {
      case "en":
        objReturn = enJson;
        break;
      default:
        objReturn = enJson;
        break;
    }

    return objReturn;
  }

  public async getCurrentLanguage() {
    let language: string;
    if (!abp.utils.getCookieValue('_language')) {
      language = "en";
    }
    else {
      language = abp.utils.getCookieValue('_language');
    }
    language = "en";
    var wanted = abp.localization.languages.filter(function(item: any){
      return (item.name === language);
    });
    
    return wanted.length > 0 ? wanted[0] : null;
  }

  public async getSystem()
  {
    abp.appServiceUrl = L('appServiceUrl','system'); 
    abp.appServiceUrlStaticFile = L('appServiceUrlStaticFile','system'); 
    abp.typesWeb = L('typesWeb','system'); 
    abp.version = L('version','system'); 
    abp.timeout = L('timeout','system'); 
    abp.authorization = L('authorization','system'); 
  }
}

export default new AbpLocalizationConfigService();
