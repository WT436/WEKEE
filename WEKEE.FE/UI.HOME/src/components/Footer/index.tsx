import * as React from 'react';
import { Button, Col, Form, Input,  Row } from 'antd';
import { Helmet } from 'react-helmet';
import Title from 'antd/lib/typography/Title';

//const urlImage = '../../images/newsletter.png'
const Footer = () => {
  return (
    <>
      <Helmet>
        <link rel="stylesheet" href="https://localhost:44324/StaticFiles/footer/footer.css" />
      </Helmet>
      <Row gutter={[16, 24]} className={'footer-top'}>
        <Col span={4} className='ftti'><img src="https://localhost:44324/StaticFiles/footer/Image/newsletter.png" /></Col>
        <Col span={8} className='ftdscto'>
          <Title level={3}>Đăng ký tài khoản nhanh Wekee</Title>
          <Title level={5}>Đừng bỏ lỡ hàng ngàn sản phẩm và chương trình siêu hấp dẫn</Title>
        </Col>
        <Col span={10} >
          <Form name="horizontal_login" layout="inline">
            <Form.Item>
              <Input className='ftmip' placeholder="Địa chỉ Email của bạn!" />
            </Form.Item>
            <Form.Item shouldUpdate>
              <Button htmlType="submit" type="primary" className='ftmbt'>
                Log in
              </Button>
            </Form.Item>
          </Form>
        </Col>
      </Row>
      <Row className='ftifmto'>
        <Col  className='ftifmtodt' span={5} >
          <ul className='ftspcl'>
            <h5>HỖ TRỢ KHÁCH HÀNG</h5>
            <li className='ftspclhl'>Hotline chăm sóc khách hàng: 1900-6035<span>(1000đ/phút , 8-21h kể cả T7, CN)</span></li>
            <li><a href='#'>Các câu hỏi thường gặp</a></li>
            <li><a href='#'>Gửi yêu cầu hỗ trợ</a></li>
            <li><a href='#'>Hướng dẫn đặt hàng</a></li>
            <li><a href='#'>Phương thức vận chuyển</a></li>
            <li><a href='#'>Chính sách đổi trả</a></li>
            <li><a href='#'>Hướng dẫn trả góp</a></li>
            <li><a href='#'>Chính sách hàng nhập khẩu</a></li>
            <li><a href='#'>Hỗ trợ khách hàng: support@wekee.vn</a></li>
            <li><a href='#'>Báo lỗi bảo mật: security@wekee.vn</a></li>
          </ul>
        </Col>
        <Col  className='ftifmtodt' span={5} >
          <ul className='ftspcl'>
            <h5>VỀ CHÚNG TÔI</h5>
            <li><a href='#'>Giới thiệu Wekee</a></li>
            <li><a href='#'>Tuyển Dụng</a></li>
            <li><a href='#'>Chính sách bảo mật thanh toán</a></li>
            <li><a href='#'>Chính sách bảo mật thông tin cá nhân</a></li>
            <li><a href='#'>Chính sách giải quyết khiếu nại</a></li>
            <li><a href='#'>Điều khoản sử dụng</a></li>
            <li><a href='#'>Giới thiệu Wekee Xu</a></li>
            <li><a href='#'>Bán hàng doanh nghiệp</a></li>
          </ul>
        </Col>
        <Col  className='ftifmtodt' span={5} >
          <ul className='ftspcl'>
            <h5>HỢP TÁC VỚI CHÚNG TÔI</h5>
            <li><a href='#'>Quy chế hoạt động </a></li>
            <li><a href='#'>Bán hàng cùng Wekee</a></li>
          </ul>
        </Col>
        <Col  className='ftifmtodt' span={5} >
          <ul>
            <h5>PHƯƠNG THỨC THANH TOÁN</h5>
            <img className='dZezzK' src='https://localhost:44324/StaticFiles/footer/Image/visa.svg'/>
            <img className='dZezzK' src='https://localhost:44324/StaticFiles/footer/Image/mastercard.svg'/>
            <img className='dZezzK' src='https://localhost:44324/StaticFiles/footer/Image/jcb.svg'/>
            <img className='dZezzK' src='https://localhost:44324/StaticFiles/footer/Image/cash.svg'/>
            <img className='dZezzK' src='https://localhost:44324/StaticFiles/footer/Image/internet-banking.svg'/>
            <img className='dZezzK' src='https://localhost:44324/StaticFiles/footer/Image/installment.svg'/>
          </ul>
        </Col>
        <Col  className='ftifmtodt' span={4} >
          <ul>
            <h5>KẾT NỐI VỚI CHÚNG TÔI</h5>
          </ul>
        </Col>
      </Row>
      <Col className='ftcbAb'>
            © 2021 - Design by WT436 - Wekee.com.vn
      </Col>
    </>
  );
};
export default Footer;
