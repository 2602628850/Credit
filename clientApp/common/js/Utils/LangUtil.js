
import i18n from '/i18n'
import * as storeUtil from '/common/js/Utils/StoreUtil'

function getLangList() {
    let langList = [
        {
            value: 'en',
            name: 'English',
        },
        {
            value: 'zh',
            name: '中文',
        }
    ]
    return langList;
}

function getLangShow(lang) {
    let result = '';
    switch (lang) {
        case 'zh':
            result = '中文';
            break;
        case 'en':
            result = 'English';
            break;
        case 'fr':
            result = 'français';
            break;
        case 'ar':
            result = 'عربي';
            break;
        case 'sr':
            result = 'Српски';
            break;
    }
    return result;
}

function setLang(lang) {
    i18n.locale = lang;
    storeUtil.set('lang', lang);
}

function getLang() {
    let lang = storeUtil.get('lang');
    let list = getLangList();
    if (!lang) {
        setLang('en');
        return 'en';
    }
    for (let i = 0; i < list.length; i++) {
        let item = list[i];
        if (item.value == lang) {
            return lang;
        }
    }
    setLang('en');
    return 'en';
}

export {
    getLangShow,
    getLangList,
    setLang,
    getLang
}