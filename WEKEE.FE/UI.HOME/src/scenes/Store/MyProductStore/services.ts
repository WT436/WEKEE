import http from '../../../services/httpService';

class MyProductStoreService { // day
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
  
export default new MyProductStoreService(); // day