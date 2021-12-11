import { IdPagedListInput } from '../../services/dto/idPagedListInput';
import { OrderByListInput } from '../../services/dto/orderByListInput';
import { PagedListOutput } from '../../services/dto/pagedListOutput';
import http from '../../services/httpService';
import { ActionAssignmentDto } from './dtos/actionAssignmentDto';
import { ActionDto } from './dtos/actionDto';
import { PermissionAssignmentDto } from './dtos/permissionAssignmentDto';
import { PermissionDto } from './dtos/permissionDto';
import { ResourceActionDto } from './dtos/resourceActionDto';
import { ResourceDto } from './dtos/resourceDto';
import { RoleDto } from './dtos/roleDto';
class APermissionService {
    //#region  Resource
    public async listResourceBasic(input: OrderByListInput): Promise<PagedListOutput<ResourceDto>> {     
        let rs = await http.get('/account-resource', {params: input});
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async getResourceBasic() {
        let rs = await http.post('/get/resource-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async editResourceBasic(input: ResourceDto) {
        let rs = await http.patch('/account-resource', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async deleteResourceBasic(ids: Number[]) {
        let rs = await http.delete('/account-resource', { params: { ids: ids } });
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async EditStatusResourceBasic(ids: Number[]) {
        let rs = await http.put('/account-resource', ids );
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    
    public async createResourceBasic(input: ResourceDto) {
        let rs = await http.post('/account-resource', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    //#endregion

    //#region  Atomic
    public async listAtomic() {
        let rs = await http.get('/account-atomic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    //#endregion

    //#region  Action
    public async watchActionBasic() {
        let rs = await http.post('/watch/action-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async updateActionBasic(input: ActionDto) {
        let rs = await http.post('/update/action-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async patchActionBasic() {
        let rs = await http.post('/patch/action-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async listActionBasic(input: OrderByListInput): Promise<PagedListOutput<ActionDto>> {
        let rs = await http.post('/list/action-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async getActionBasic() {
        let rs = await http.post('/get/action-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async editActionBasic(input: ActionDto) {
        let rs = await http.post('/edit/action-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async deleteActionBasic(ids: Number[]) {
        let rs = await http.delete('/delete/action-basic', { params: { ids: ids } });
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async createActionBasic(input: ActionDto) {
        let rs = await http.post('/create/action-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    //#endregion

    //#region  Permission
    public async watchPermissionBasic() {
        let rs = await http.post('/watch/permission-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async updatePermissionBasic(input: PermissionDto) {
        let rs = await http.post('/update/permission-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async patchPermissionBasic() {
        let rs = await http.post('/patch/permission-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async listPermissionBasic(input: OrderByListInput): Promise<PagedListOutput<PermissionDto>> {
        let rs = await http.post('/list/permission-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async getPermissionBasic() {
        let rs = await http.post('/get/permission-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async editPermissionBasic(input: PermissionDto) {
        let rs = await http.post('/edit/permission-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async deletePermissionBasic(ids: Number[]) {
        let rs = await http.delete('/delete/permission-basic', { params: { ids: ids } });
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async createPermissionBasic(input: PermissionDto) {
        let rs = await http.post('/create/permission-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    //#endregion

    //#region  Role
    public async watchRoleBasic() {
        let rs = await http.post('/watch/role-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async updateRoleBasic(input: RoleDto) {
        let rs = await http.post('/update/role-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async patchRoleBasic() {
        let rs = await http.post('/patch/role-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async listRoleBasic(input: OrderByListInput): Promise<PagedListOutput<RoleDto>> {
        let rs = await http.post('/list/role-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async getRoleBasic() {
        let rs = await http.post('/get/role-basic');
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async editRoleBasic(input: RoleDto) {
        let rs = await http.post('/edit/role-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async deleteRoleBasic(ids: Number[]) {
        let rs = await http.delete('/delete/role-basic', { params: { ids: ids } });
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    public async createRoleBasic(input: RoleDto) {
        let rs = await http.post('/create/role-basic', input);
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }
    //#endregion

    //#region  Resource Action
    public async getResourceActionBasic(input: IdPagedListInput): Promise<PagedListOutput<ResourceActionDto>> {
        let rs = await http.get('/get/resource-action-basic', {
            params: {
                pageIndex: input.pageIndex,
                pageSize: input.pageSize,
                idAction: input.id
            }
        });
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async insertOrUpdateResourceActionBasic(input: ResourceActionDto): Promise<ResourceActionDto> {
        let rs = await http.post('/update/resource-action-basic', input);
        if (rs) {
            return input;
        }
        else {
            return rs;
        }
    }
    //#endregion

    //#region  Action Assignment
    public async getActionAssignmentBasic(input: IdPagedListInput): Promise<PagedListOutput<ResourceActionDto>> {
        let rs = await http.get('/get/action-assignment-basic', {
            params: {
                pageIndex: input.pageIndex,
                pageSize: input.pageSize,
                idPermission: input.id
            }
        });
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async insertOrUpdateActionAssignmentBasic(input: ActionAssignmentDto): Promise<ActionAssignmentDto> {
        let rs = await http.post('/update/action-assignment-basic', input);
        if (rs) {
            return input;
        }
        else {
            return rs;
        }
    }
    //#endregion
    
    //#region  Permission Assignment
    public async getPermissionAssignmentBasic(input: IdPagedListInput): Promise<PagedListOutput<PermissionAssignmentDto>> {
        let rs = await http.get('/get/permission-assignment-basic', {
            params: {
                pageIndex: input.pageIndex,
                pageSize: input.pageSize,
                idRole: input.id
            }
        });
        if (rs) {
            return rs.data;
        }
        else {
            return rs;
        }
    }

    public async insertOrUpdatePermissionAssignmentBasic(input: PermissionAssignmentDto): Promise<PermissionAssignmentDto> {
        let rs = await http.post('/update/permission-assignment-basic', input);
        if (rs) {
            return input;
        }
        else {
            return rs;
        }
    }
    //#endregion

}

export default new APermissionService();