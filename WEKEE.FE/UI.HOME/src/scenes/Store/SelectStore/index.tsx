//#region  import
import { Avatar, Form, Input, List, Modal } from "antd";
import * as React from "react";
import { useEffect, useState } from "react";
import { Helmet } from "react-helmet";
import { useDispatch, useSelector } from "react-redux";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import { watchPageStart } from "./actions";
import reducer from "./reducer";
import saga from "./saga";
import { makeSelectLoading } from "./selectors";
declare var abp: any;
//#endregion
export interface ISelectStoreProps {
  // đây
  location: any;
}
const key = "selectstore"; // đây
const stateSelector = createStructuredSelector<any, any>({
  loading: makeSelectLoading(),
});

export default function SelectStore(props: ISelectStoreProps) {
  // Đây
  useInjectReducer(key, reducer);
  useInjectSaga(key, saga);

  const dispatch = useDispatch();
  const { loading } = useSelector(stateSelector);
  useEffect(() => {
    dispatch(watchPageStart());
  }, []);

  const data = [
    {
      title: "Ant Design Title 1",
    },
    {
      title: "Ant Design Title 2",
    },
    {
      title: "Ant Design Title 3",
    },
    {
      title: "Ant Design Title 4",
    },
  ];

  //#region Select storce
  const OnSelect = () => {
    setVisible(true);
  };
  //#endregion

  //#region Login Store
  const [form] = Form.useForm();

  interface Values {
    title: string;
    description: string;
    modifier: string;
  }

  const [visible, setVisible] = useState(false);

  const onCreate = (values: any) => {
    console.log("Received values of form: ", values);
    setVisible(false);
  };
  const onCancel = () => {
    setVisible(false);
  };
  //#endregion

  return (
    <>
      <Helmet>
        <link rel="stylesheet" href={abp.serviceAlbumCss + "/store.css"} />
      </Helmet>
      <List
        itemLayout="horizontal"
        dataSource={data}
        renderItem={(item) => (
          <span className="hwYeVEHXKV" onClick={OnSelect}>
            <List.Item>
              <List.Item.Meta
                avatar={<Avatar src="https://joeschmoe.io/api/v1/random" />}
                title={item.title}
                description="Ant Design, a design language for background applications, is refined by Ant UED Team"
              />
              <div>Nhân viên</div>
            </List.Item>
          </span>
        )}
      />

      <Modal
        visible={visible}
        title="ĐĂNG NHẬP TÀI KHOẢN"
        okText="ĐĂNG NHẬP"
        cancelText="THOÁT"
        onCancel={onCancel}
        onOk={() => {
          form
            .validateFields()
            .then((values) => {
              form.resetFields();
              onCreate(values);
            })
            .catch((info) => {
              console.log("Validate Failed:", info);
            });
        }}
      >
        <Form
          form={form}
          layout="vertical"
          name="form_in_modal"
          initialValues={{ modifier: "public" }}
        >
          <Form.Item
            name="title"
            label="Title"
            rules={[
              {
                required: true,
                message: "Please input the title of collection!",
              },
            ]}
          >
            <Input.Password />
          </Form.Item>
        </Form>
      </Modal>
    </>
  );
}
