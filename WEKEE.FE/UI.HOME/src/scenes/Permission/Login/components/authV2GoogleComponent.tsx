//#region import
import React, { useEffect, useRef, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { L } from '../../../../lib/abpUtility';
import { createStructuredSelector } from 'reselect';
import GoogleLogin from 'react-google-login';
import { GoogleLogout } from 'react-google-login';
import moment from 'moment';
import { loginAouthGoogleStart } from '../actions';
declare var abp: any;
//#endregion

interface IAuthV2GoogleComponentProps {

}
const stateSelector = createStructuredSelector<any, any>({

});
export default function AuthV2GoogleComponent(props: IAuthV2GoogleComponentProps) {

  const dispatch = useDispatch();

  const {
  } = useSelector(stateSelector);

  const responseGoogle = (response: any) => {
    if (response) {
      dispatch(loginAouthGoogleStart({
        id: response.profileObj.googleId,
        email: response.profileObj.email,
        tokenId: response.tokenId,
        firstName: response.profileObj.familyName,
        lastName: response.profileObj.givenName,
        avatar: response.profileObj.imageUrl,
      }));
      console.log(response);
    }
  }
  const responseGoogleFail = (response: any) => {
    console.log("responseGoogleFail",response);
  }
  return (
    <>
      <GoogleLogin
        className='WXNtxhZyyS'
        clientId="427046489843-ceaqn3k3fvmaaq6dbgrdvfeaduol579s.apps.googleusercontent.com"
        render={renderProps => (
          <div onClick={renderProps.onClick}>
            <img title={L("LOGIN_WITH_GOOGLE", "LOGIN")} src='https://localhost:44327/album-resources/album/imageSystem/google.png' />
          </div>
        )}
        buttonText="Google"
        onSuccess={responseGoogle}
        onFailure={responseGoogleFail}
        isSignedIn={true}
        cookiePolicy={'single_host_origin'}
        prompt="select_account consent"
      />
    </>
  )
}