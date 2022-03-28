import { Button, Card, Col, DatePicker, Drawer, Input, Row, Select, Timeline } from 'antd'
import React, { Component } from 'react'
import { Area, AreaChart, CartesianGrid, Legend, Tooltip, XAxis, YAxis } from 'recharts';
const { Option } = Select;
interface Props {

}
const data = [
    {
        "name": "Page A",
        "uv": 4000,
        "pv": 2400,
        "amt": 2400
    },
    {
        "name": "Page B",
        "uv": 3000,
        "pv": 1398,
        "amt": 2210
    },
    {
        "name": "Page C",
        "uv": 2000,
        "pv": 9800,
        "amt": 2290
    },
    {
        "name": "Page D",
        "uv": 2780,
        "pv": 3908,
        "amt": 2000
    },
    {
        "name": "Page E",
        "uv": 1890,
        "pv": 4800,
        "amt": 2181
    },
    {
        "name": "Page F",
        "uv": 2390,
        "pv": 3800,
        "amt": 2500
    },
    {
        "name": "Page G",
        "uv": 3490,
        "pv": 4300,
        "amt": 2100
    }
]
export default class CommonRoleComponents extends Component<Props> {
    state = { visible: false };
    showDrawer = () => {
        this.setState({
            visible: true,
        });
    };

    onClose = () => {
        this.setState({
            visible: false,
        });
    };

    render() {
        return (
            <>
                <Row gutter={[10, 10]}>
                    <Col>
                        <Button type="primary" onClick={this.showDrawer}>Hướng Dẫn</Button>
                        <Drawer
                            title="Biểu đồ phân quyền"
                            placement="right"
                            width='50%'
                            closable={false}
                            onClose={this.onClose}
                            visible={this.state.visible}
                        >
                            <Col span={24}>
                                <Row style={{ textAlign: 'center' }}>
                                    <Col span={12}>
                                        <Card size='small' title="Thao tác kết nối">
                                            Tạo ra nhiều kiểu phân quyền từ 2 điểm xanh gần nhất.Mỗn điểm xanh trên và một điểm xanh dưới tạo ra 1 điểm đỏ.
                                        </Card>
                                    </Col>
                                    <Col span={12}>
                                        <Card size='small' title="Thao tác chính">
                                            Các thành phần chính. Thông tin có thể đọc. Bạn cần tạo ra các điểm phân quyền xanh này. Và kết nối chúng bằng điểm đỏ.
                                        </Card>
                                    </Col>
                                </Row>
                                <Row justify="center">
                                    <Timeline mode="alternate" style={{ width: '100%', padding: '10px', margin: '0 20px' }}>
                                        <Timeline.Item>
                                            <Card size='small' title='Resource'>
                                                Resource là lớp cơ sở của tất cả các phần tử mô hình trong ngôn ngữ mô hình hóa hệ thống đại diện cho các Resource được bảo vệ.
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item color="red">
                                            <Card size='small' title='ResourceAction'>
                                                Mỗi Resource cung cấp action hoặc nhiều actions và mỗi action thuộc về chính xác một Resource, được biểu thị bằng action tổng hợp tổng hợp ResourceAction
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item>
                                            <Card size='small' title='Action'>
                                               Lưu một hành động nào đó cho một phân vùng url nào đó
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item color="red">
                                            <Card size='small' title='Action Assignment'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item>
                                            <Card size='small' title='Permission'>
                                                Quyền truy cập vào lượng url 
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item color="red">
                                            <Card size='small' title='Permission Assignment'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item>
                                            <Card size='small' title='Algorithm Role'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item color="red">
                                            <Card size='small' title='Constraint Assignment'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item>
                                            <Card size='small' title='Role'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item color="red">
                                            <Card size='small' title='Subject Assignment'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item>
                                            <Card size='small' title='Subject'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item color="red">
                                            <Card size='small' title='Subject Group'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item>
                                            <Card size='small' title='Group'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                        <Timeline.Item color="red">
                                            <Card size='small' title='User Account'>
                                                Card content
                                            </Card>
                                        </Timeline.Item>
                                    </Timeline>
                                </Row>
                            </Col>
                        </Drawer>
                    </Col>
                    <Col>
                        <Button type="primary" onClick={this.showDrawer}>Hướng Dẫn</Button>
                    </Col>
                </Row>
                <Row>
                    <Card style={{ width: '100%', margin: '10px 20px' }} size='small' title="Số lượng quyền cho từng thành phần (Record)" >
                        <Card.Grid style={{ width: '20%' }}>Resource: 4000</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>Resource Action: 2100</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>Action: 4300</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>1890</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>1589</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>1472</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>1557</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>2564</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>3289</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>4473</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>1244</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>1634</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>1342</Card.Grid>
                        <Card.Grid style={{ width: '20%' }}>631</Card.Grid>
                    </Card>
                </Row>
                <Row>
                    <Card style={{ width: '100%' }}>
                        <Row gutter={[10, 10]}>
                            <Col span={10} >Biểu đồ thống kê</Col>
                            <Col span={4}>
                                <Input.Group compact>
                                    <Input style={{ width: '50%', borderRadius: '5px 0 0 5px' }} disabled defaultValue="Thời gian" />
                                    <Select defaultValue='ads' style={{ width: '50%', borderRadius: '0 5px 5px 0' }}>
                                        <Option value=".com">.com</Option>
                                        <Option value=".jp">.jp</Option>
                                        <Option value=".cn">.cn</Option>
                                        <Option value=".org">.org</Option>
                                    </Select>
                                </Input.Group>
                            </Col>
                            <Col span={10}>
                                <Input.Group compact>
                                    <Input style={{ width: '30%', borderRadius: '5px 0 0 5px' }} disabled defaultValue="input content" />
                                    <DatePicker.RangePicker style={{ width: '70%', borderRadius: '0 5px 5px 0' }} />
                                </Input.Group>
                            </Col>
                        </Row>
                        <AreaChart width={1000} height={250} data={data}
                            margin={{ top: 10, right: 30, left: 0, bottom: 0 }}>
                            <defs>
                                <linearGradient id="colorUv" x1="0" y1="0" x2="0" y2="1">
                                    <stop offset="5%" stopColor="#8884d8" stopOpacity={0.8} />
                                    <stop offset="95%" stopColor="#8884d8" stopOpacity={0} />
                                </linearGradient>
                                <linearGradient id="colorPv" x1="0" y1="0" x2="0" y2="1">
                                    <stop offset="5%" stopColor="#82ca9d" stopOpacity={0.8} />
                                    <stop offset="95%" stopColor="#82ca9d" stopOpacity={0} />
                                </linearGradient>
                                <linearGradient id="colorPamt" x1="0" y1="0" x2="0" y2="1">
                                    <stop offset="5%" stopColor="#150799" stopOpacity={0.8} />
                                    <stop offset="95%" stopColor="#150799" stopOpacity={0} />
                                </linearGradient>
                            </defs>
                            <XAxis dataKey="name" />
                            <YAxis />
                            <CartesianGrid strokeDasharray="3 3" />
                            <Tooltip />
                            <Legend verticalAlign="top" height={36} />
                            <Area type="monotone" dataKey="uv" stroke="#8884d8" fillOpacity={1} fill="url(#colorUv)" />
                            <Area type="monotone" dataKey="pv" stroke="#82ca9d" fillOpacity={1} fill="url(#colorPv)" />
                            <Area type="monotone" dataKey="amt" stroke="#150799" fillOpacity={1} fill="url(#colorPamt)" />
                        </AreaChart>
                    </Card>
                </Row>
                <Row></Row>
            </>
        )
    }
}
