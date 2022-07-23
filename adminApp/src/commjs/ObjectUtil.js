/**
 * 判断对象是否为空
 * @param {Object} obj 对象
 */
function isEmpty(obj) {
    if (typeof obj == "number") {
        return false;
    }
    if (typeof obj == 'boolean') {
        return false;
    }
    if (typeof obj == "undefined" || obj == null || obj == "" || obj == [] || obj == {}) {
        console.log(obj);
        return true;
    } else {
        return false;
    }
}

/**
 * 复制文本
 * @param text  文本内容
 * @param callback  回调
 */
function copyText(text, callback) {
    if (navigator.clipboard) {
        navigator.clipboard.writeText(text)
        callback && callback(true)
        return
    }
    callback && callback(false)
}

function getAuditStatusEnums() {
    return [
        {
            title: '审核中',
            value: '10'
        },
        {
            title: '审核通过',
            value: '20'
        },
        {
            title: '审核未通过',
            value: '30'
        }
    ]
}

function getAuditStatus(status) {
    let auditStatus = getAuditStatusEnums();
    let text = '-';
    for (let i = 0; i < auditStatus.length; i++) {
        let item = auditStatus[i];
        if (item.value == status) {
            text = item.title;
            break;
        }
    }
    return text;
}

export {
    isEmpty,
    copyText,
    getAuditStatusEnums,
    getAuditStatus,
}