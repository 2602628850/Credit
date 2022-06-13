import { createI18n } from 'vue-i18n'

import zh from './text-zh'
import en from './text-en'

const i18n = createI18n({
    locale: 'en', // set locale
    messages: {
        zh: zh,
        en: en,
    },
})

export default i18n