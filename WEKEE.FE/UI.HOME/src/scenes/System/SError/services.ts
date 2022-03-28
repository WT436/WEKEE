import { OrderByListInput } from '../../../services/dto/orderByListInput';
import http from '../../../services/httpService';

class SErrorService {
    public async getListErrorSystemStart(orderByPageListInput: OrderByListInput) {

        let rs = await http.post('/list/error-system', orderByPageListInput);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async fixErrorSystemStart(id: Number) {
        let rs = await http.get('/edit/error-system',{params:{id:id}});
        if (rs) {
            return id;
        }
        else {
            return rs;
        }
    }
}

export default new SErrorService();