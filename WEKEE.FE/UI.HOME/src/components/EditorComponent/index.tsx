import { notification } from "antd";
import { convertToRaw, EditorState } from "draft-js";
import draftToHtml from "draftjs-to-html";
import React, { useEffect, useState } from "react";
import { Editor } from "react-draft-wysiwyg";
declare var abp: any;

//#region CONST
//#endregion
export interface IEditorComponent {
    editorHTMLCallback: any;
    maxLengthText?: number;
}


function uploadImageCallBack(file: string | Blob) {
    return new Promise(
        (resolve, reject) => {
            const xhr = new XMLHttpRequest();
            xhr.open('POST', abp.serviceAlbumAPI + "patch/upload-post");
            xhr.setRequestHeader('Authorization', abp.auth.getToken());
            const data = new FormData();
            data.append('file', file);
            xhr.send(data);
            xhr.addEventListener('load', () => {
                const response = JSON.parse(xhr.responseText);
                console.log(xhr);
                response.data.link = abp.serviceAlbumImage + response.data.link
                resolve(response);
            });
            xhr.addEventListener('error', () => {
                notification.error({
                    message: "Thất bại",
                    description: "Đã có lỗi sảy ra!",
                    placement: 'bottomRight'
                });
                reject();
            });
        }
    );
}

export default function EditorComponent(props: IEditorComponent) {


    const [editorState, seteditorState] = useState(EditorState.createEmpty());

    const onEditorStateChange = (editorState: any) => {
        draftToHtml(convertToRaw(editorState.getCurrentContent()));
        seteditorState(editorState);
    };

    useEffect(() => {
        props.editorHTMLCallback(draftToHtml(convertToRaw(editorState.getCurrentContent())));
    }, [editorState]);

    //#region Function
    // const _getLengthOfSelectedText = () => {
    //     const currentSelection = editorState.getSelection();
    //     const isCollapsed = currentSelection.isCollapsed();

    //     let length = 0;

    //     if (!isCollapsed) {
    //         const currentContent = editorState.getCurrentContent();
    //         const startKey = currentSelection.getStartKey();
    //         const endKey = currentSelection.getEndKey();
    //         const startBlock = currentContent.getBlockForKey(startKey);
    //         const isStartAndEndBlockAreTheSame = startKey === endKey;
    //         const startBlockTextLength = startBlock.getLength();
    //         const startSelectedTextLength = startBlockTextLength - currentSelection.getStartOffset();
    //         const endSelectedTextLength = currentSelection.getEndOffset();
    //         const keyAfterEnd = currentContent.getKeyAfter(endKey);
    //         console.log(currentSelection)
    //         if (isStartAndEndBlockAreTheSame) {
    //             length += currentSelection.getEndOffset() - currentSelection.getStartOffset();
    //         } else {
    //             let currentKey = startKey;

    //             while (currentKey && currentKey !== keyAfterEnd) {
    //                 if (currentKey === startKey) {
    //                     length += startSelectedTextLength + 1;
    //                 } else if (currentKey === endKey) {
    //                     length += endSelectedTextLength;
    //                 } else {
    //                     length += currentContent.getBlockForKey(currentKey).getLength() + 1;
    //                 }

    //                 currentKey = currentContent.getKeyAfter(currentKey);
    //             };
    //         }
    //     }

    //     return length;
    // }

    // const _handleBeforeInput = () => {
    //     const currentContent = editorState.getCurrentContent();
    //     const currentContentLength = currentContent.getPlainText('').length;
    //     const selectedTextLength = _getLengthOfSelectedText();

    //     if (currentContentLength - selectedTextLength > props.maxLengthText - 1) {
    //         console.log('you can type max ten characters');

    //         return 'handled';
    //     }
    //     else {
    //         return undefined;
    //     }
    // }

    // const _handlePastedText = (pastedText: any) => {
    //     const currentContent = editorState.getCurrentContent();
    //     const currentContentLength = currentContent.getPlainText('').length;
    //     const selectedTextLength = _getLengthOfSelectedText();

    //     if (currentContentLength + pastedText.length - selectedTextLength > props.maxLengthText) {
    //         console.log('you can type max ten characters');
    //         return 'handled';
    //     }
    //     else {
    //         return undefined;
    //     }
    // }

    // const _handleChange = (editorState: any) => {
    //     seteditorState(editorState);
    // }

    // const _handleBeforeInput2 = () => {
    //     const currentContent = editorState.getCurrentContent();
    //     const currentContentLength = currentContent.getPlainText('').length

    //     if (currentContentLength > props.maxLengthText - 1) {
    //         console.log('you can type max ten characters');
    //         return 'handled';
    //     }
    //     return undefined;
    // }
    //#endregion

    return (<>
        <Editor
            editorState={editorState}
            wrapperClassName="kVcFNEFdzL"
            editorClassName="WEabvZfAHr"
            onEditorStateChange={onEditorStateChange}
            toolbar={{
                image: { uploadCallback: uploadImageCallBack, alt: { present: true, mandatory: true } },
            }}
        />
    </>);
}
