import { PagedListOutput } from '../../services/dto/pagedListOutput';
import http from '../../services/httpService';
import { AccountAdminCreate } from './dtos/accountAdminCreate'
import { AccountShowDtos } from './dtos/accountShowDtos';
import { SubjectAssignmentDto } from './dtos/subjectAssignmentDto';

class AAccountService {
    public async authenticate() {
        let rs = await http.post('/get/log-in');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async removeAvatarUpload(input: string) {
        let rs = await http.get('/patch/remove-image', { params: { input: input } });
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async createAccountAdmin(accountAdminCreate: AccountAdminCreate) {
        let rs = await http.post('/patch/admin-process-account', accountAdminCreate);
        if (rs) {
            return rs;
        }
        else {
            return rs;
        }
    }

    public async listAccountAdmin(accountAdminCreate: any): Promise<PagedListOutput<AccountShowDtos>> {
        let rs = await http.post('/list/admin-account', accountAdminCreate);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async listSubjectAccount(input: any): Promise<AccountShowDtos[]> {
        let rs = await http.get('/watch/subject-basic', {params:{id:input}});
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    
    public async listSubjectAssignStart(input: any): Promise<PagedListOutput<SubjectAssignmentDto>> {
        let rs = await http.get('/watch/subject-assignment-basic', {params:{id:input}});
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async changePermissionAccountStart(idSubject:any,idRole:any): Promise<boolean> {
        let rs = await http.get('/update/subject-assignment-basic', {params:{idSubject:idSubject,idRole:idRole}});
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    
    public async deleteAccountStart(id:any): Promise<Number> {
        let rs = await http.delete('/delete/admin-account', {params:{idAccount:id}});
        if (rs) {
            return id;
        }
        else {
            return rs;
        }
    }
}

export default new AAccountService();