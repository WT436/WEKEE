import http from '../../../services/httpService';

class SelectStoreService { // day
    public async authenticate() {
        let rs = await http.post('/get/log-in');       
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
}
  
export default new SelectStoreService(); // day