import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { SearchOrderPageInput } from '../../../services/dto/searchOrderPageInput';
import http from '../../../services/httpService';
import { CategoryProductInsertDto } from './dtos/CategoryProductInsertDto';
import { CategoryProductReadDto } from './dtos/CategoryProductReadDto';

class ACategoryService {

    public async getCategoryMapService(){
        let rs = await http.get('/get-map-category');
        console.log("/get-map-category");
        console.log(rs);
        if (rs){
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async createCategoryAdminStart(category: CategoryProductInsertDto) {
        let rs = await http.post('/create-category', category);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async getCategoryAdminStart(input : SearchOrderPageInput) : Promise<PagedListOutput<CategoryProductReadDto>> {
        let rs = await http.get('/category-product-get-all', {
            params:  input
        });
        console.log(rs.data)
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
}

export default new ACategoryService();