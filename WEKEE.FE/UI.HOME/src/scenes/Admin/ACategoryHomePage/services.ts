import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { SearchOrderPageInput } from '../../../services/dto/searchOrderPageInput';
import http from '../../../services/httpService';
import { CategoryHomePageReadDto } from './dto/categoryHomePageReadDto';

class ACategoryHomePageService { // day
    //#region  Name

    public async getCategoryAdminStart(input: SearchOrderPageInput): Promise<PagedListOutput<CategoryHomePageReadDto>> {
        let rs = await http.get('/get-data-category-review', {
            params: input
        });
        console.log(rs.data)
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    //#endregion
}

export default new ACategoryHomePageService(); // day