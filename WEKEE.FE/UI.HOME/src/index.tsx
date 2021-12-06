import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import * as moment from 'moment';

import App from './App';
import { BrowserRouter } from 'react-router-dom';
import Utils from './utils/utils';
import registerServiceWorker from './registerServiceWorker';
import abpLocalizationConfigService from './services/abpLocalizationConfigService';
import defaultConfig from './localization/defaultConfig.json';
import loginService from './scenes/Login/services';
import configureStore from './redux/configureStore';

declare var abp: any;
Utils.setLocalization();

abpLocalizationConfigService.getLocalization().then(async function (res) {
    Utils.extend(true, abp, defaultConfig);

    await loginService.getIp();

    if (!!abp.auth.getToken()) {
        await loginService.getIp();
    }

    var loadingEl = document.getElementById('root-loading');
    if (loadingEl) {
        loadingEl.remove();
    }

    abp.localization.values = res;

    abpLocalizationConfigService.getCurrentLanguage().then(function (res) {
        abp.localization.currentLanguage = res;
        abp.localization.currentCulture = {
            name: res.name,
            displayName: res.displayName
        }
    });

    abpLocalizationConfigService.getSystem();

    moment.locale(abp.utils.getCookieValue('_language'));

    const initialState = {};
    const store = configureStore(initialState);
    ReactDOM.render(
        <Provider store={store}>
            <BrowserRouter>
                <App />
            </BrowserRouter>
        </Provider>,
        document.getElementById('root') as HTMLElement
    );

    registerServiceWorker();
});