function set(key,object) {
    uni.setStorageSync(key, object)
}
function get(key) {
    return uni.getStorageSync(key);
}

export {
    set,
    get
}