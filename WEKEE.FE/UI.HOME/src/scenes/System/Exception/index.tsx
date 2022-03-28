import { Row } from 'antd'
import * as React from 'react'
import { Helmet } from 'react-helmet'
import queryString from 'query-string';

declare var abp: any;
var urlCss = abp.serviceAlbumCss + "/errorClient500.css";

export interface IException {
    location:any;
}
export default function Exception(props: IException) {
    
    let params = queryString.parse(props.location.search);
    let statusDefault =params.status == undefined|| params.status == null || params.status =='' ? 500 : params.status;
    let messageDefault =params.message == undefined|| params.message == null || params.message =='' ? 'Hệ Thống Đang Nâp Cấp...': params.message;

    let status = { '--status-error': "'"+statusDefault+"'" } as React.CSSProperties;

    return (
        <div style={{ height: '100vh', display: 'block', position: 'relative' }}>
            <Helmet>
                <link rel="stylesheet" href={urlCss} />
            </Helmet>
            <div className="stars"></div>
            <div className="twinkling"></div>
            <div className="clouds"></div>
            <div className="moon">
                <ul>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                </ul>
                <div className="clock__bob" style={status}></div>
            </div>
            <div className="body">
                <span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                </span>
                <div className="base">
                    <span></span>
                    <div className="face"></div>
                </div>
            </div>
            <div className="longfazers">
                <span></span>
                <span></span>
                <span></span>
                <span></span>
            </div>
            <div className="directional-Error">
                <span>
                   {messageDefault}
                </span>
                <div>
                    <a href="#">
                        <span></span><span></span><span></span><span></span>
                        HOME
                    </a>
                    <a href="#">
                        <span></span><span></span><span></span><span></span>
                        lOGIN
                    </a>
                    <a href="#">
                        <span></span><span></span><span></span><span></span>
                        HOME
                    </a>
                    <a href="#">
                        <span></span><span></span><span></span><span></span>
                        SUPPORT
                    </a>
                    <a href="#">
                        <span></span><span></span><span></span><span></span>
                        EXIT
                    </a>
                </div>
            </div>
        </div>
    )
}
