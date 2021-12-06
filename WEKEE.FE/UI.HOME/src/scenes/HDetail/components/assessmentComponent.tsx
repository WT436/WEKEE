import React, { SyntheticEvent, useEffect, useRef, useState } from 'react'
import { Button, Divider, Input, message, Modal, Pagination, Progress, Rate, Select, Typography } from 'antd'
import { CameraOutlined, CaretDownOutlined, CloseCircleOutlined, DislikeOutlined, DropboxOutlined, EllipsisOutlined, FileImageOutlined, FireOutlined, HeartOutlined, HeartTwoTone, LikeOutlined, MessageOutlined, NotificationOutlined, PushpinOutlined, SmileOutlined, StarFilled } from '@ant-design/icons';
import Slider from 'react-slick';
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { Picker } from "emoji-mart";
import "emoji-mart/css/emoji-mart.css";
import { LazyLoadImage } from 'react-lazy-load-image-component';
import 'react-lazy-load-image-component/src/effects/blur.css';
import { useDispatch, useSelector } from 'react-redux';
import { dislikeEvaluatesProductStart, getRepcommentAssessmentStart, likeEvaluatesProductStart, overviewEvaluatesProductStart, removeYouAssessmentStart, repcommentAssessmentStart, reviewEvaluatesProductStart } from '../actions';
import { createStructuredSelector } from 'reselect';
import { makeSelectgetEvaluatesProductDto, makeSelectLoading, makeSelectreviewEvaluatesOutputDto } from '../selectors';
import { ImageEvaluatesDtos } from '../dtos/imageEvaluatesDtos';
import { ReviewEvaluatesInputDto } from '../dtos/reviewEvaluatesInputDto';
import { ReviewEvaluatesOutputDto } from '../dtos/reviewEvaluatesOutputDto';
import TextArea from 'antd/lib/input/TextArea';
import Dragger from 'antd/lib/upload/Dragger';
import { RepCommentEvaluatesOutputDto } from '../dtos/repCommentEvaluatesOutputDto';
const { Text } = Typography;
const { Option } = Select;
declare var abp: any;
interface IAssessmentComponent { id: number }

const settings3 = {
    dots: false,
    infinite: true,
    speed: 1000,
    slidesToShow: 5,
    slidesToScroll: 3,
    autoplaySpeed: 5000,
    pauseOnHover: true
};

const desc = ['Rất không hài lòng', 'Không hài lòng', 'Ổn', 'Tuyệt vời', 'Rất tuyệt vời'];

function DateTimeProcess(input: Date) {
    // Find the distance between now and the count down date
    var distance = new Date().getTime() - new Date(input).getTime();

    // Time calculations for days, hours, minutes and seconds
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));

    if (days !== 0 && days <= 5) {
        return days + " ngày";
    }
    if (days !== 0 && days > 5) {
        return input.toString().split('T')[0];
    }
    if (hours !== 0) {
        return hours + " giờ";
    }
    if (minutes >= 5) {
        return minutes + " phút"
    }
    else {
        return "vừa xong"
    }
}

function beforeUpload(file: { type: string; size: number; }) {
    const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
    if (!isJpgOrPng) {
        message.error('You can only upload JPG/PNG file!');
    }
    const isLt2M = file.size / 1024 / 1024 < 2;
    if (!isLt2M) {
        message.error('Image must smaller than 2MB!');
    }
    return isJpgOrPng && isLt2M;
}

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    getEvaluatesProductDto: makeSelectgetEvaluatesProductDto(),
    reviewEvaluatesOutputDto: makeSelectreviewEvaluatesOutputDto(),
});

export default function AssessmentComponent(props: IAssessmentComponent) {
    const dispatch = useDispatch();

    const {
        loading, getEvaluatesProductDto,
        reviewEvaluatesOutputDto
    } = useSelector(stateSelector);

    useEffect(() => {
        dispatch(overviewEvaluatesProductStart(props.id));
    }, []);

    const [sumStar, setsumStar] = useState(0);
    const [average, setaverage] = useState(0);

    useEffect(() => {
        setsumStar(getEvaluatesProductDto.numberStarOne
            + getEvaluatesProductDto.numberStarTwo
            + getEvaluatesProductDto.numberStarThree
            + getEvaluatesProductDto.numberStarFour
            + getEvaluatesProductDto.numberStarFive
        );
        setaverage((getEvaluatesProductDto.numberStarOne * 1
            + getEvaluatesProductDto.numberStarTwo * 2
            + getEvaluatesProductDto.numberStarThree * 3
            + getEvaluatesProductDto.numberStarFour * 4
            + getEvaluatesProductDto.numberStarFive * 5) / (getEvaluatesProductDto.numberStarOne
                + getEvaluatesProductDto.numberStarTwo
                + getEvaluatesProductDto.numberStarThree
                + getEvaluatesProductDto.numberStarFour
                + getEvaluatesProductDto.numberStarFive));
    }, [getEvaluatesProductDto]);

    //modal
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [imageevaluates, setimageevaluates] = useState<string[]>([]);
    const [selectImage, setselectImage] = useState('');

    // review 
    const [provisoOnselect, setprovisoOnselect] = useState<number[]>([]);
    const [pageOnselect, setPageOnselect] = useState<number>(0);

    const onSelectProviso = (input: number) => {
        if (provisoOnselect.some((element) => element === input)) {
            var dataprovisoOnselect = provisoOnselect.filter(function (item: number) {
                return item !== input
            });
            setprovisoOnselect(dataprovisoOnselect);
            dispatch(reviewEvaluatesProductStart({
                proviso: dataprovisoOnselect,
                id: props.id,
                page: 0
            }));
        }
        else {
            provisoOnselect.push(input);
            setprovisoOnselect(provisoOnselect);
            dispatch(reviewEvaluatesProductStart({
                proviso: provisoOnselect,
                id: props.id,
                page: 0
            }));
        }
    };

    useEffect(() => {
        dispatch(reviewEvaluatesProductStart({
            proviso: [],
            id: props.id,
            page: 0
        }));
    }, []);
    // like and dislike
    const likeReviewEvaluate = (levelEvaluates: number,
        idEvaluates: number) => {
        if (!!abp.auth.getToken()) {
            dispatch(likeEvaluatesProductStart(levelEvaluates, idEvaluates));
        }
        else {
            message.warning("Bạn cần đăng nhập để like bình luận này!");
        }
    };

    const disLikeReviewEvaluate = (levelEvaluates: number,
        idEvaluates: number) => {
        if (!!abp.auth.getToken()) {
            dispatch(dislikeEvaluatesProductStart(levelEvaluates, idEvaluates));
        }
        else {
            message.warning("Bạn cần đăng nhập để phản đối bình luận này!");
        }
    };
    // comment
    const [showCommnetButton, setshowCommnetButton] = useState(0);

    const showCommnetButtonfunc = (idEvaluates: number) => {
        if (!!abp.auth.getToken()) {
            if (showCommnetButton === idEvaluates) {
                setshowCommnetButton(0);
            }
            else {
                setassessmentRepcommentInput("");
                setShowEmojis(false);
                setshowCommnetButton(idEvaluates);
            }
        }
        else {
            message.warning("Bạn cần đăng nhập để phản hồi bình luận này!");
        }
    }

    const textRef = useRef<any>();

    const onChangeHandler = function (e: SyntheticEvent) {
        const target = e.target as HTMLTextAreaElement;
        textRef.current.style.height = "30px";
        textRef.current.style.height = `${target.scrollHeight}px`;
    };

    const [assessmentRepcommentInput, setassessmentRepcommentInput] = useState("");
    const [showEmojis, setShowEmojis] = useState(false);

    const addEmoji = (e: any) => {
        const refin = textRef.current;
        refin.focus();
        const start = assessmentRepcommentInput.substring(0, refin.selectionStart);
        const end = assessmentRepcommentInput.substring(refin.selectionStart);
        const text = start + e.native + end
        setassessmentRepcommentInput(text);
    };

    const [imageRepevaluates, setimageRepevaluates] = useState<string[]>([]);
    const propsImage = {
        name: 'files',
        multiple: true,
        action: 'https://localhost:44324/v1/api/create/image-evaluates',
        onChange(info: any) {
            const { status } = info.file;
            if (status === 'done') {
                message.success(`${info.file.name} file uploaded successfully.`);
                setimageRepevaluates([...imageRepevaluates, info.file.response]);
            } else if (status === 'error') {
                message.error(`${info.file.name} file upload failed.`);
            }
        },
        onDrop(e: any) {
            console.log('Dropped files', e.dataTransfer.files);
        },
    };

    const sendRepCommentlv1 = (id: number) => {
        dispatch(repcommentAssessmentStart({
            id: id,
            content: assessmentRepcommentInput,
            image: imageRepevaluates,
            product: props.id,
            levelEvaluates: 1
        }
        ));
    }

    const sendRepCommentlv2 = (id: number) => {
        dispatch(repcommentAssessmentStart({
            id: id,
            content: assessmentRepcommentInput,
            image: imageRepevaluates,
            product: props.id,
            levelEvaluates: 2
        }
        ));
    }
    //  show data comment product
    const [pageCommnet, setpageCommnet] = useState(0);
    const showMoreCommnet = (id: number, level: number) => {
        dispatch(getRepcommentAssessmentStart(id, level, pageCommnet));
        //setpageCommnet(pageCommnet + 1);
    }

    return (
        <div className='OJkXBiXyst'>
            <p className='SwswGUqGyh'>Đánh giá Sản Phẩm</p>
            <div style={{ display: 'flex' }}>
                <div className='VVrWvYaWfC'>
                    <div className='oDJettRwyU'>
                        <span className='OCPtBwOIOD'>{parseFloat(average.toString()).toFixed(2)}</span>
                        <div className='cmNTtEtbtK'>
                            <Rate className='GzDAOKKKVj' allowHalf value={Math.round(average * 100) / 100} disabled defaultValue={3} />
                            <span className='UCrJvRxSQd'>{sumStar} nhận xét</span>
                        </div>
                    </div>
                    <div className='IoOXkVMAAl'>
                        <div className='YgpLxSKxnS'>
                            <Rate className='EcgcSmPrVd' disabled defaultValue={5} />
                            <Progress className='FacGcvSojo' size="small" percent={(getEvaluatesProductDto.numberStarFive / sumStar) * 100} showInfo={false} />
                            <Text className='BAySdinqWS'>{getEvaluatesProductDto.numberStarFive}</Text>
                        </div>
                        <div className='YgpLxSKxnS'>
                            <Rate className='EcgcSmPrVd' disabled defaultValue={4} />
                            <Progress className='FacGcvSojo' size="small" percent={(getEvaluatesProductDto.numberStarFour / sumStar) * 100} showInfo={false} />
                            <Text className='BAySdinqWS'>{getEvaluatesProductDto.numberStarFour}</Text>
                        </div>
                        <div className='YgpLxSKxnS'>
                            <Rate className='EcgcSmPrVd' disabled defaultValue={3} />
                            <Progress className='FacGcvSojo' size="small" percent={(getEvaluatesProductDto.numberStarThree / sumStar) * 100} showInfo={false} />
                            <Text className='BAySdinqWS'>{getEvaluatesProductDto.numberStarThree}</Text>
                        </div>
                        <div className='YgpLxSKxnS'>
                            <Rate className='EcgcSmPrVd' disabled defaultValue={2} />
                            <Progress className='FacGcvSojo' size="small" percent={(getEvaluatesProductDto.numberStarTwo / sumStar) * 100} showInfo={false} />
                            <Text className='BAySdinqWS'>{getEvaluatesProductDto.numberStarTwo}</Text>
                        </div>
                        <div className='YgpLxSKxnS'>
                            <Rate className='EcgcSmPrVd' disabled defaultValue={1} />
                            <Progress className='FacGcvSojo' size="small" percent={(getEvaluatesProductDto.numberStarOne / sumStar) * 100} showInfo={false} />
                            <Text className='BAySdinqWS'>{getEvaluatesProductDto.numberStarOne}</Text>
                        </div>
                    </div>
                </div>
                <div className='SCeJkHPGQW'>
                    <div className='eHCQBsdJND'>
                        {
                            getEvaluatesProductDto.imageReview.sort().map((item: ImageEvaluatesDtos, index: number) => {
                                if (index < 7) {
                                    return (
                                        <div className='cKqErgPkfl' onClick={() => setIsModalVisible(true)}>
                                            <LazyLoadImage
                                                alt={"ádsda"}
                                                effect="blur"
                                                src={abp.appServiceUrlStaticFile + '/' + item.image80x80} />
                                        </div>
                                    );
                                }
                                if (index === 7) {
                                    return (
                                        <div className='cKqErgPkfl' onClick={() => setIsModalVisible(true)}>
                                            <LazyLoadImage
                                                alt={"ádsda"}
                                                effect="blur"
                                                className="cKqErgPkfl"
                                                src={abp.appServiceUrlStaticFile + '/' + item.image80x80} />
                                            <span className='VNDntFciDM'>Hiển thị thêm {getEvaluatesProductDto.imageReview.length - 6} ảnh khác</span>
                                        </div>
                                    );
                                }
                            })
                        }
                    </div>
                    <div className='mgALtMnzRY'>
                        <a className={provisoOnselect.some((element) => element === 5) ? "JzCIqJTYYL  QWgTuTyObU" : "JzCIqJTYYL "} onClick={() => onSelectProviso(5)} >5 <StarFilled className='tLyWEpJTkm' /></a>
                        <a className={provisoOnselect.some((element) => element === 4) ? "JzCIqJTYYL  QWgTuTyObU" : "JzCIqJTYYL "} onClick={() => onSelectProviso(4)}>4 <StarFilled className='tLyWEpJTkm' /></a>
                        <a className={provisoOnselect.some((element) => element === 3) ? "JzCIqJTYYL  QWgTuTyObU" : "JzCIqJTYYL "} onClick={() => onSelectProviso(3)}>3 <StarFilled className='tLyWEpJTkm' /></a>
                        <a className={provisoOnselect.some((element) => element === 2) ? "JzCIqJTYYL  QWgTuTyObU" : "JzCIqJTYYL "} onClick={() => onSelectProviso(2)}>2 <StarFilled className='tLyWEpJTkm' /></a>
                        <a className={provisoOnselect.some((element) => element === 1) ? "JzCIqJTYYL  QWgTuTyObU" : "JzCIqJTYYL "} onClick={() => onSelectProviso(1)}>1 <StarFilled className='tLyWEpJTkm' /></a>
                        <a className='JzCIqJTYYL' >Mới nhất</a>
                        <a className='JzCIqJTYYL' >Hình Ảnh</a>
                        <a className='JzCIqJTYYL' >Mua Hàng</a>
                    </div>
                </div>

                <Modal
                    title="Ảnh từ khách hàng"
                    footer={null}
                    visible={isModalVisible}
                    onCancel={() => setIsModalVisible(false)}
                    bodyStyle={{ textAlign: 'center' }}
                >
                    <div className='cKqErgPkfl' style={{ width: '100%', height: '100%' }}>
                        <LazyLoadImage
                            alt={"Lựa chọn image"}
                            effect="blur"
                            onClick={() => setIsModalVisible(true)}
                            src={!selectImage ? '' : abp.appServiceUrlStaticFile + '/' + selectImage} />
                    </div>
                    <div className="CDBhRpMxwl">
                        <Slider {...settings3}>
                            {
                                getEvaluatesProductDto.imageReview.map((element: ImageEvaluatesDtos) => {
                                    return (<img className={"LmqLbjIyYc" + " " + (selectImage === element.image80x80 ? "bFpTBTrDfH" : "")}
                                        onClick={() => setselectImage(element.image340x340)}
                                        src={abp.appServiceUrlStaticFile + "/" + element.image80x80}
                                        alt={''} />)
                                })
                            }
                        </Slider>
                    </div>
                </Modal>
            </div>

            <div className='SCeJkHPGQW' style={{ width: 'initial', margin: '5px 0' }}>
                {reviewEvaluatesOutputDto.map((item: ReviewEvaluatesOutputDto) => {
                    return (
                        <div className='BDVwiLlqTH'>
                            <div className='LNOnCyyxQa'>
                                <div className='QmalboputO'>
                                    <img className='UsOtLlsjsj' src={abp.appServiceUrlStaticFile + "/" + item.accountReview.avartar} alt="" />
                                    <div className='UyXPaSOgcb'>
                                        <p className='afjfYlfVaY'>{item.accountReview.fullName}</p>
                                        <p>Đã tham gia {DateTimeProcess(item.accountReview.dateJoin)}</p>
                                    </div>
                                </div>
                                <p className='qCuxZuQMLY'>Đã viết: {item.accountReview.userEvaluates} Đánh giá</p>
                                <p className='qCuxZuQMLY'>Đã viết: {item.accountReview.userRepEvaluates} Phản hồi</p>
                                <p className='qCuxZuQMLY'>Đã nhận: {item.accountReview.userGetFavorites} Lượt cảm ơn</p>
                                <p className='qCuxZuQMLY'>Đã nhận: {item.accountReview.userGetObjections} Lượt vô nghĩa</p>
                            </div>
                            <div className='cfgjlVcRMQ'>
                                <div className='liyeWatEpD'>
                                    <Rate className='LgfLOmjQMW' value={item.starNumber} disabled defaultValue={3} />
                                    {desc[item.starNumber - 1]}
                                </div>
                                <p className='uVOrGSOXsc'>
                                    <DropboxOutlined />
                                    <span>Đã mua hàng</span>
                                    {JSON.parse(item.pinFeeling).map((element: string) => {
                                        return (
                                            <span>{element} <PushpinOutlined /></span>
                                        )
                                    })
                                    }
                                </p>
                                <div className='GWmMQEuuPK'>{item.content}</div>
                                <div className="gRDMnIHgdU">
                                    {item.image.length === 0 ? <></> :
                                        item.image.sort().map((itemImage: ImageEvaluatesDtos, index: number) => {
                                            if (index < 7) {
                                                return (
                                                    <div className='cKqErgPkfl' onClick={() => setIsModalVisible(true)}>
                                                        <LazyLoadImage
                                                            alt={"ádsda"}
                                                            effect="blur"
                                                            src={abp.appServiceUrlStaticFile + '/' + itemImage.image80x80} />
                                                    </div>
                                                );
                                            }
                                            if (index === 7) {
                                                return (
                                                    <div className='cKqErgPkfl' onClick={() => setIsModalVisible(true)}>
                                                        <LazyLoadImage
                                                            alt={"ádsda"}
                                                            effect="blur"
                                                            className="cKqErgPkfl"
                                                            src={abp.appServiceUrlStaticFile + '/' + itemImage.image80x80} />
                                                        <span className='VNDntFciDM'>Hiển thị thêm {item.image.length - 6} ảnh khác</span>
                                                    </div>
                                                );
                                            }
                                        })
                                    }
                                </div>
                                <div className='puUSLSJlzZ'>
                                    <div className='dnBQQNdEwT'>Màu Sắc <span>TRẮNG</span></div>
                                    <div className='dnBQQNdEwT'>Kích thước <span>L</span></div>
                                    <div className='dnBQQNdEwT'>{DateTimeProcess(item.dateReview)}</div>
                                </div>
                                <div className='GSUNSRmwNO'> {/*dLGiHcVLYs*/}
                                    <Button type="link" className={item.youLike ? 'aUlQvWccLA dLGiHcVLYs' : 'aUlQvWccLA'} onClick={() => likeReviewEvaluate(0, item.idReview)} icon={<LikeOutlined />}> Hữu ích ({item.likeReview})</Button>
                                    <Button type="link" className={item.youDisLike ? 'aUlQvWccLA dLGiHcVLYs' : 'aUlQvWccLA'} onClick={() => disLikeReviewEvaluate(0, item.idReview)} icon={<DislikeOutlined />}>Vô nghĩa ({item.dislikeReview})</Button>
                                    <Button type="link" className='aUlQvWccLA' onClick={() => showCommnetButtonfunc(item.idReview)} icon={<MessageOutlined />}>Phản hồi({item.commentReview})</Button>
                                </div>
                                {item.commentReview === 0 ? <></> :
                                    <div style={{ width: '100%', textAlign: 'end', height: 20, lineHeight: 1 }}>
                                        <Select
                                            className="rzYsHrKrLz"
                                            defaultValue="phuHopNhat"
                                            suffixIcon={<CaretDownOutlined />}
                                            bordered={false}
                                        >
                                            <Option value="phuHopNhat">Phù Hợp Nhất</Option>
                                            <Option value="MoiNhat">Mới Nhất</Option>
                                            <Option value="TatCaBinhLuan">Tất Cả Bình Luận</Option>
                                        </Select>
                                    </div>
                                }
                                {showCommnetButton === item.idReview
                                    ? <div className="YLmZhraSLJ">
                                        <div style={{ position: 'relative' }}>
                                            <textarea
                                                ref={textRef}
                                                value={assessmentRepcommentInput}
                                                onChange={(e: any) => { onChangeHandler(e); setassessmentRepcommentInput(e.target.value) }}
                                                onKeyPress={(e) => { (e.key === 'Enter' && e.preventDefault()) ?? sendRepCommentlv1(item.idReview) }}
                                                className='eNzvzXxgia'
                                                name=""
                                                id=""
                                                style={{ paddingRight: 50, minHeight: 30, margin: 0 }}
                                                placeholder="Viết Bình luận ..."
                                            />

                                            <div className='ktwIxbdVgY'>
                                                <SmileOutlined
                                                    className="JlgHldYWir"
                                                    onClick={() => setShowEmojis(!showEmojis)}
                                                    style={{ color: 'rgba(0,0,0,.45)' }}
                                                />
                                                <Dragger
                                                    className="JlgHldYWir"
                                                    method='POST'
                                                    beforeUpload={beforeUpload}
                                                    {...propsImage}
                                                    style={{ width: 80, height: 80 }}
                                                >
                                                    <CameraOutlined />
                                                </Dragger>
                                            </div>
                                            {showEmojis && (
                                                <div className="KIBtbcoNUB">
                                                    <Picker onSelect={(e: any) => addEmoji(e)} />
                                                </div>
                                            )}
                                        </div>
                                        <div className="RPjVXBNSbL">
                                            {
                                                imageRepevaluates.map((item: string, index) => {
                                                    if (index < 7) {
                                                        return (
                                                            <div className='cKqErgPkfl'>
                                                                <CloseCircleOutlined onClick={() => { setimageRepevaluates(imageRepevaluates.filter(item2 => item2 !== item)); dispatch(removeYouAssessmentStart(item)) }} />
                                                                <LazyLoadImage
                                                                    alt={"ádsda"}
                                                                    effect="blur"
                                                                    onClick={() => setIsModalVisible(true)}
                                                                    src={abp.appServiceUrlStaticFile + '/' + item} />
                                                            </div>
                                                        );
                                                    }
                                                    if (index === 7) {
                                                        return (
                                                            <div className='cKqErgPkfl'>
                                                                <LazyLoadImage
                                                                    alt={"ádsda"}
                                                                    effect="blur"
                                                                    className="cKqErgPkfl"
                                                                    src={abp.appServiceUrlStaticFile + '/' + item} />
                                                                <span className='VNDntFciDM'>Hiển thị thêm {imageevaluates.length - 6} ảnh khác</span>
                                                            </div>
                                                        );
                                                    }
                                                })
                                            }
                                        </div>
                                    </div>
                                    : <></>}
                                {item.repCommentEvaluates.map((repcomment: RepCommentEvaluatesOutputDto) => {
                                    return (
                                        <div className="nNVxrpOumL">
                                            <div className="nNVxrpOumL">
                                                <div className="JwMWGpetPE">
                                                    <div className="GGKviWLHJH">
                                                        <div className="ZCcIcopBuX"></div>
                                                        <img className='EuEinMInHi' src={abp.appServiceUrlStaticFile + '/' + repcomment.avatarAccount} alt="" />
                                                    </div>
                                                    <div className="FwoJYIRsKF">
                                                        <div className="vytbSMnWZY">
                                                            <div className="EFShuNSjPz">{repcomment.nameAccount}</div>
                                                            <div className="bRVbtcpFyr">{repcomment.comment}</div>
                                                            <div className="RqaOLkKjHG">
                                                                <HeartOutlined /> {repcomment.numberLike}
                                                                <FireOutlined /> {repcomment.numberDisLike}
                                                                <MessageOutlined /> {repcomment.numberComment}
                                                                <NotificationOutlined /> {repcomment.numberRepost}
                                                            </div>
                                                        </div>
                                                        <ul className="nxLBfYxLOR">
                                                            <li className={repcomment.youLike ? "iQrPsVgAsr" : ""} onClick={() => likeReviewEvaluate(1, repcomment.id)} >Thích</li>
                                                            <li className={repcomment.youDisLike ? "iQrPsVgAsr" : ""} onClick={() => disLikeReviewEvaluate(1, repcomment.id)} >Không thích </li>
                                                            <li onClick={() => showCommnetButtonfunc(repcomment.id)}>Phản hồi</li>
                                                            <li>{DateTimeProcess(repcomment.dateComment)}</li>
                                                        </ul>
                                                    </div>
                                                    <EllipsisOutlined />
                                                </div>
                                                {repcomment.repCommentEvaluates.map((replycomment: RepCommentEvaluatesOutputDto) => {
                                                    return (
                                                        <div className="ByKVhDewtl uIDCSlWITT">
                                                            <div className="GGKviWLHJH">
                                                                <div className="bHexDsHAAu"></div>
                                                                <img className='EuEinMInHi' src={abp.appServiceUrlStaticFile + '/' + replycomment.avatarAccount} alt="" />
                                                            </div>
                                                            <div className="FwoJYIRsKF">
                                                                <div className="vytbSMnWZY">
                                                                    <div className="EFShuNSjPz">{replycomment.nameAccount}</div>
                                                                    <div className="bRVbtcpFyr">{replycomment.comment}</div>
                                                                </div>
                                                                <ul className="nxLBfYxLOR">
                                                                    <li onClick={() => showCommnetButtonfunc(repcomment.id)}>Phản hồi</li>
                                                                    <li>{DateTimeProcess(replycomment.dateComment)}</li>
                                                                </ul>
                                                            </div>
                                                            <EllipsisOutlined />
                                                        </div>)
                                                })}
                                                {
                                                    showCommnetButton === repcomment.id
                                                        ? <div className="ByKVhDewtl uIDCSlWITT">
                                                            <div className="GGKviWLHJH">
                                                                <div className="bHexDsHAAu"></div>
                                                                <img className='EuEinMInHi' src={abp.appServiceUrlStaticFile + '/album/product/wekee-wekee-065117d465185d35584804fb16f5ded6-011709-23092021--012154-23092021-S340x340.jpg'} alt="" />
                                                            </div>
                                                            <div className="FwoJYIRsKF">
                                                                <textarea
                                                                    ref={textRef}
                                                                    value={assessmentRepcommentInput}
                                                                    onChange={(e: any) => { onChangeHandler(e); setassessmentRepcommentInput(e.target.value) }}
                                                                    onKeyPress={(e) => { (e.key === 'Enter' && e.preventDefault()) ?? sendRepCommentlv2(repcomment.id) }}
                                                                    className='eNzvzXxgia'
                                                                    name=""
                                                                    id=""
                                                                    style={{ paddingRight: 50, minHeight: 30, margin: 0 }}
                                                                    placeholder="Viết Bình luận ..."
                                                                />
                                                                <div className='ktwIxbdVgY'>
                                                                    <SmileOutlined
                                                                        className="JlgHldYWir"
                                                                        onClick={() => setShowEmojis(!showEmojis)}
                                                                        style={{ color: 'rgba(0,0,0,.45)' }}
                                                                    />
                                                                </div>
                                                                {showEmojis && (
                                                                    <div className="KIBtbcoNUB">
                                                                        <Picker onSelect={(e: any) => addEmoji(e)} />
                                                                    </div>
                                                                )}
                                                            </div>
                                                        </div>
                                                        : <></>
                                                }
                                                {(repcomment.numberComment - repcomment.repCommentEvaluates.length) < 1
                                                    ? <></>
                                                    : <div className="ByKVhDewtl uIDCSlWITT">
                                                        <div className="GGKviWLHJH">
                                                            <div className="bHexDsHAAu"></div>
                                                        </div>
                                                        <div onClick={() => showMoreCommnet(repcomment.id, 2)}
                                                            className="FwoJYIRsKF TsoLLSKzSx">
                                                            Xem thêm {
                                                                (repcomment.numberComment - repcomment.repCommentEvaluates.length) <= 10
                                                                    ? (repcomment.numberComment - repcomment.repCommentEvaluates.length)
                                                                    : 10
                                                            } bình luận
                                                        </div>
                                                    </div>
                                                }

                                            </div>
                                        </div>
                                    )
                                })}
                                {
                                    (item.commentReview - item.repCommentEvaluates.length) < 1
                                        ? <></>
                                        : <Divider className="VTsdGRPspc" orientation="left">
                                            <a onClick={() => showMoreCommnet(item.idReview, 1)}>
                                                Xem thêm {(item.commentReview - item.repCommentEvaluates.length) >= 10
                                                    ? "10"
                                                    : item.commentReview - item.repCommentEvaluates.length} bình luận
                                            </a>
                                        </Divider>
                                }
                            </div>
                        </div>
                    );
                })}
                {reviewEvaluatesOutputDto.length < 10 ? <></> : <Divider className="VTsdGRPspc" orientation="left">Xem thêm 10 bình luận</Divider>}
            </div>
        </div >
    )
}
