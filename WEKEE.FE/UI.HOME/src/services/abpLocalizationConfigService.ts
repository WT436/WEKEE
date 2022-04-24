import { L } from '../lib/abpUtility';
import enJson from '../localization/en.json';
import viJson from '../localization/vi.json';

declare var abp: any;

class AbpLocalizationConfigService {
  public async getLocalization() {
    let language;
    if (!abp.utils.getCookieValue('_language')) {
      language = "vi";
    }
    else {
      language = abp.utils.getCookieValue('_language');
    }

    let objReturn;
    switch(language) {
      case "vi":
        objReturn = viJson;
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
      language = "vi";
    }
    else {
      language = abp.utils.getCookieValue('_language');
    }
    var wanted = abp.localization.languages.filter(function(item: any){
      return (item.name === language);
    });
    
    return wanted.length > 0 ? wanted[0] : null;
  }

  public async getSystem()
  {
    abp.appServiceUrl = L('appServiceUrl','SYSTEM'); 
    abp.appServiceUrlStaticFile = L('appServiceUrlStaticFile','SYSTEM'); 
    abp.typesWeb = L('typesWeb','SYSTEM'); 
    abp.version = L('version','SYSTEM'); 
    abp.timeout = L('timeout','SYSTEM'); 
    abp.authorization = L('authorization','SYSTEM'); 
  }
}

export default new AbpLocalizationConfigService();
