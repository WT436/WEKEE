import React, { Component } from 'react'
import { Helmet } from 'react-helmet'

interface Props {

}

export default class ErrorClient403 extends Component<Props> {
    render() {
        return (
            <div>
                <Helmet>
                    <link rel="stylesheet" href="style.css" />
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
                        Hệ Thống Đang Nâng Cấp. . .
                    </span>
                    <div>
                        <a href="#">
                            <span></span><span></span><span></span><span></span>
                            Trang Chủ
                        </a>
                        <a href="#">
                            <span></span><span></span><span></span><span></span>
                            Báo Cáo
                        </a>
                    </div>
                </div>
            </div>
        )
    }
}
