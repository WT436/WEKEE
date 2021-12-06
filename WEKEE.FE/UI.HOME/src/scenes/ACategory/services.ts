import { Console } from 'console';
import http from '../../services/httpService';
import { CategoryDtos } from './dtos/categoryDtos';

class ACategoryService {

    public async createCategoryAdminStart(category: CategoryDtos) {
        let rs = await http.post('/create/create-category', category);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async getCategoryAdminStart(level: Number, categorymain: Number, orderNumber: Number) {
        let rs = await http.get('/get/get-data-category', {
            params: {
                level: level,
                categorymain: categorymain,
                orderNumber: orderNumber
            }
        });
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
}

export default new ACategoryService();