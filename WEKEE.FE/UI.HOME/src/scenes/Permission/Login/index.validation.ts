import { L } from '../../../lib/abpUtility';

const rules = {
    UserName: [{ required: true, message: L('Common.ThisFieldIsRequired') }],
    Password: [{ required: true, message: L('Common.ThisFieldIsRequired') }]
};

export default rules;
