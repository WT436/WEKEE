//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
declare var abp: any;
import moment from 'moment';
//#endregion

interface IBasicComponentProps {

}
const stateSelector = createStructuredSelector<any, any>({

});
export default function BasicComponent(props: IBasicComponentProps) {

    const dispatch = useDispatch();

    const {
    } = useSelector(stateSelector);

    return (
      <></>
    )
}
