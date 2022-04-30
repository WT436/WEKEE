//#region import
import { CarryOutOutlined, FormOutlined, QuestionCircleOutlined } from '@ant-design/icons';
import { Card, Col, message, Row, Select, Tree } from 'antd';
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { getUserProfileStart } from '../actions';
import { UserProfileCompactReadDto } from '../dto/userProfileCompactReadDto';
import { makeuserProfile } from '../selectors';
const { Option } = Select;

declare var abp: any;
//#endregion

interface IOverviewComponentProps {

}
const stateSelector = createStructuredSelector<any, any>({
    userProfile: makeuserProfile()
});
interface DataNode {
    title: any;
    key: string;
    level: number;
    isLeaf?: boolean;
    children?: DataNode[];
};

const initTreeData: DataNode[] = [
    { title: 'Vai trò : Admin ', key: '0', level: 0 },
    { title: 'Vai trò : User ', key: '1', level: 0 }
];

// It's just a simple demo. You can use tree map to optimize update perf.
function updateTreeData(list: DataNode[], key: React.Key, children: DataNode[]): DataNode[] {
    return list.map(node => {
        if (node.key === key) {
            return {
                ...node,
                children,
            };
        }
        if (node.children) {
            return {
                ...node,
                children: updateTreeData(node.children, key, children),
            };
        }
        return node;
    });
}

export default function OverviewComponent(props: IOverviewComponentProps) {

    const dispatch = useDispatch();

    const {
        userProfile
    } = useSelector(stateSelector);

    const successGuide = () => {
        message.success('Lựa chọn tài khoản và gán/hủy quyền cho tài khoản ấy. Nếu như tài khoản "SYSTEM" thì là gán dùng chung', 10);
    };

    const [treeData, setTreeData] = useState(initTreeData);

    const onLoadData = ({ key, children, level }: any) =>
        new Promise<void>(resolve => {
            if (children) {
                resolve();
                return;
            }
            setTimeout(() => {
                setTreeData(origin =>
                    updateTreeData(origin, key, [
                        { title: 'PERMISSION', key: `${key}-0`, level: level + 1 },
                        { title: 'PERMISSION', key: `${key}-1`, level: level + 1, isLeaf: true },
                        { title: 'PERMISSION', key: `${key}-2`, level: level + 1 },
                    ]),
                );
                resolve();
            }, 1000);
        });
    //#region SEARCH SELCECT

    let timeout: any;
    let currentValue: any;

    const _handleSearchModal = (value: any) => {
        console.log(timeout);
        if (timeout) {
            clearTimeout(timeout);
            timeout = null;
        }
        currentValue = value;

        timeout = setTimeout(() => dispatch(getUserProfileStart({ text: value })), 1000);
    };

    const _handleChangeModal = (value: any) => {

    };

    //#endregion
    return (
        <>
            <Row gutter={[10, 10]}>
                <Col span={8}>
                    <Card title="Biểu đồ 1" size="small" type="inner" style={{ minHeight: '276px' }} >

                    </Card>
                </Col>
                <Col span={8}>
                    <Card title="Biểu đồ 2" size="small" type="inner" style={{ minHeight: '276px' }} >

                    </Card>
                </Col>
                <Col span={8}>
                    <Card title="Bảng" size="small" type="inner" style={{ minHeight: '276px' }} >

                    </Card>
                </Col>
            </Row>
            <br />
            <Row gutter={[10, 10]}>
                <Col span={12}>
                    <Row gutter={[10, 10]} style={{ marginBottom: '5px' }}>
                        <Col span={1} style={{ height: '100%', lineHeight: 2 }}>
                            <QuestionCircleOutlined style={{ color: 'red' }} onClick={successGuide} />
                        </Col>
                        <Col span={23}>
                            <Select
                                showSearch
                                defaultActiveFirstOption={false}
                                showArrow={false}
                                filterOption={false}
                                style={{ width: '100%' }}
                                onSearch={(value: any) => _handleSearchModal(value)}
                                onChange={(value: any) => _handleChangeModal(value)}
                                notFoundContent={null}
                                placeholder="Lựa chọn tài khoản trong hệ thống!"
                            >
                                {userProfile.map((province: UserProfileCompactReadDto) => (
                                    <Option value={province.id}>{province.userName}</Option>
                                ))}
                            </Select>
                        </Col>
                    </Row>

                    <Card title="Card title" size="small" type="inner">
                        <Tree
                        showLine={{ showLeafIcon: false }}
                        defaultExpandParent={false}
                        showIcon={true}
                        treeData={treeData}
                        loadData={onLoadData}
                        />
                    </Card>
                </Col>
                <Col span={12}>
                    <Card title="Card title" size="small" type="inner">
                        <p>Card content</p>
                        <p>Card content</p>
                        <p>Card content</p>
                        <p>Card content</p>
                        <p>Card content</p>
                        <p>Card content</p>
                        <p>Card content</p>
                    </Card>
                </Col>
            </Row>
        </>
    )
}
