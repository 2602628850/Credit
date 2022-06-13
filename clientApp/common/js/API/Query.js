import BaseUrl from "./BaseUrl";
import BaseHttpQuest from './BaseHttpQuest'


export const get = (path, param) => {
    return BaseHttpQuest('GET', BaseUrl.host + path, param);
}

export const post = (path, param) => {
    return BaseHttpQuest('POST', BaseUrl.host + path, param);
}