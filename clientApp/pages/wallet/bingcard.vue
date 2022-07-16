<template>
	
	<register-input-item tip="国家" class="mgt" style="margin-top: 20px;">
		<template v-slot:img>
			<view class="input-icon iconfont icon-diqiu"></view>
		</template>
		<template v-slot:default>
			<view class="flex-row-between" style="position: relative" @click="countryPickerShow">
				<input disabled :placeholder="$t('register.countryTip')" class="input mgr"
					v-model="editItem.CountryName" />
				<view class="text-tip iconfont icon-xiala" style="font-size: 16px"></view>
	
				<picker style="position: absolute;width: 100%;height: 100%;z-index: 9999;top: 0;left: 0;"
					:range="countryList" :index="countryIndex" range-key="name" @change="countryChange"></picker>
			</view>
		</template>
	</register-input-item>
	
	
	<register-input-item tip="银行名称" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-wodekefu"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('public.mailTip')" class="input" v-model="editItem.Username" />
		</template>
	</register-input-item>
	
	<register-input-item tip="银行卡号" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-yanzheng"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('public.nikenameTip')" class="input" v-model="editItem.Nickname" />
		</template>
	</register-input-item>

<register-input-item tip="持卡人" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-geren"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('public.nikenameTip')" class="input" v-model="editItem.Nickname" />
		</template>
	</register-input-item>

<register-input-item tip="手机号码" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-lianxi"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('public.nikenameTip')" class="input" v-model="editItem.Nickname" />
		</template>
	</register-input-item>



</template>

<script>
	import RegisterInputItem from "../register/register-input-item.vue";
	export default {
		data() {
			return {
				countryList: [{
						name: 'England',
						code: 'U.K.'
					},
					{
						name: 'United States',
						code: 'USA'
					},
					{
						name: '中国',
						code: 'zh'
					}
				],
				countryIndex: 0,
				editItem: {
					CountryName: '',
					countryCode: '',
				},
			}
		},
		components: {
			RegisterInputItem
		},
		methods:{
			countryChange(e) {
				this.countryIndex = e.detail.value;
				let item = this.countryList[this.countryIndex];
				this.editItem.countryCode = item.code;
				this.editItem.CountryName = item.name;
			},
		}
	}
</script>

<style>
	
	
</style>
