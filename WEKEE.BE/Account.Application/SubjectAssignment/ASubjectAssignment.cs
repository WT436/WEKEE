
using Account.Domain.BoundedContext;
using Account.Domain.Entitys;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Utils.Exceptions;
using Account.Domain.Dto;

namespace Account.Application.SubjectAssignment
{
    public class ASubjectAssignment : ISubjectAssignment
    {
        private readonly SubjectQuery _subjectQuery = new SubjectQuery();
        private readonly SubjectAssignmentQuery _subjectAssignmentQuery = new SubjectAssignmentQuery();
        private readonly RoleQuery _roleQuery = new RoleQuery();

        public async Task<bool> CreateOrUpdateSubjectAssignment(int idSubject, int idRole)
        {
            //laay duwx lieeuj
            var dataSa = await _subjectAssignmentQuery.GetIdSubjectAndIdRole(idSubject: idSubject, idRole: idRole);
            if (dataSa == null)
            {
                await _subjectAssignmentQuery.Create(id_Subject: idSubject, id_RoleId: idRole);
            }
            else
            {
                dataSa.IsActive = !dataSa.IsActive;
                _subjectAssignmentQuery.Update(dataSa);
            }
            return true;
        }

        public async Task<List<SubjectAssignmentDto>> WatchAccountSubject(int id_Account)
        {
            // laays danh sach subject 
            bool checkExists = await _subjectQuery.CheckExists(id_Account: id_Account);
            if (!checkExists)
            {
                await _subjectQuery.Create(id_Account: id_Account);
            }

            var lstSubject = await _subjectAssignmentQuery.GetAllJoinWithIdAccount(id_Account: id_Account);
            // lay danh sach role 
            var lstRole = await _roleQuery.GetAllActive();
            return MapPagedListOutput.MapingpagedListOutput(subjectAssignments: lstSubject, roles: lstRole.ToList());
        }

        public async Task<List<SubjectAssignmentDto>> WatchSubjectRole(int id_Subject)
        {
            // laays danh sach subject 
            bool checkExists = await _subjectQuery.CheckIdExists(id_Subject: id_Subject);
            if (!checkExists)
            {
                throw new ClientException(400, "Subject khong ton tai");
            }

            var lstSubject = await _subjectAssignmentQuery.GetAllJoinWithIdSubject(id_Subject: id_Subject);
            // lay danh sach role 
            var lstRole = await _roleQuery.GetAllActive();
            return MapPagedListOutput.MapingpagedListOutput(subjectAssignments: lstSubject, roles: lstRole.ToList());
        }
    }
}
