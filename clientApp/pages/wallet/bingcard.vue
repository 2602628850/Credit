<template>
	
		<navigation-bar :title="$t('wallet.bindbank')"></navigation-bar>
		<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">
	
	<register-input-item :tip="$t('wallet.contry')" class="mgt" style="margin-top: 20px;">
		<template v-slot:img>
			<view class="input-icon iconfont icon-diqiu"></view>
		</template>
		<template v-slot:default>
			<view class="flex-row-between" style="position: relative" @click="countryPickerShow">
				<input disabled class="input mgr"
					v-model="editItem.CountryName" />
				<view class="text-tip iconfont icon-xiala" style="font-size: 16px"></view>
	
				<picker style="position: absolute;width: 100%;height: 100%;z-index: 9999;top: 0;left: 0;"
					:range="countryList" :index="countryIndex" range-key="name" @change="countryChange"></picker>
			</view>
		</template>
	</register-input-item>
	
	<register-input-item :tip="$t('wallet.bank')" class="mgt" style="margin-top: 20px;">
		<template v-slot:img>
			<view class="input-icon iconfont icon-qianbao"></view>
		</template>
		<template v-slot:default>
			<view class="flex-row-between" style="position: relative" @click="countryPickerShow">
				<input disabled class="input mgr"
					v-model="editItem.BankName" />
				<view class="text-tip iconfont icon-xiala" style="font-size: 16px"></view>
	
				<picker style="position: absolute;width: 100%;height: 100%;z-index: 9999;top: 0;left: 0;"
					:range="bankList" :index="bankIndex" range-key="name" @change="bankChange"></picker>
			</view>
		</template>
	</register-input-item>
	
	
	<register-input-item :tip="$t('wallet.zhihang')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-wodekefu"></view>
		</template>
		<template v-slot:default>
			<input  class="input" v-model="editItem.BankBranch" />
		</template>
	</register-input-item>
	
	<register-input-item :tip="$t('wallet.card')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-yanzheng"></view>
		</template>
		<template v-slot:default>
			<input  class="input" v-model="editItem.CardNo" />
		</template>
	</register-input-item>

<register-input-item :tip="$t('wallet.person')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-geren"></view>
		</template>
		<template v-slot:default>
			<input  class="input" v-model="editItem.BindUser" />
		</template>
	</register-input-item>

<register-input-item :tip="$t('wallet.phone')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-lianxi"></view>
		</template>
		<template v-slot:default>
			<input  class="input" v-model="editItem.Phone" />
		</template>
	</register-input-item>


<view class="button-primary margin-left-right-20 flex-row-center" @click="doRegister" style="margin-top: 20px;">
		{{$t('wallet.submit')}}
	</view>
	</app-content-view>

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
				bankList:[],//银行
				countryIndex: 0,
				bankIndex:0,
				editItem: {
					CountryName: '',
					countryCode: '',
					BankName:'',
					BankId:'',
				},
			}
		},
		components: {
			RegisterInputItem
		},
		mounted() {
			//获取银行列表
			this.GetBank();
		},
		methods:{
			countryChange(e) {
				this.countryIndex = e.detail.value;
				let item = this.countryList[this.countryIndex];
				this.editItem.countryCode = item.code;
				this.editItem.CountryName = item.name;
			},
			bankChange(e){
				this.bankIndex = e.detail.value;
				let item = this.bankList[this.bankIndex];
				this.editItem.BankId = item.code;
				this.editItem.BankName = item.name;
			},
			doRegister(){
				var url = "/User/BindBankCard";
				this.ApiPost(url, this.editItem).then(res => {
					if(res.data=="bind_success"){
					this.showMsg(this.$t('wallet.bindsuccess'));
					//注册成功后跳个人钱包
					uni.navigateTo({
						url: '/pages/wallet/index'
					})
					return;
					}else{
						this.showMsg(res.data);
					}
					
				})
			},
			showMsg(msg) {
				uni.showToast({
					title: msg,
					duration: 2000,
				})
			},
			GetBank() {
				var url = "/User/GetBanks";
				this.ApiGet(url).then(res => {
					var lists= res.data
					for(var i=0;i<res.data.length;i++){
						var objc = new Object();
						objc.name=res.data[i].bankName;
						objc.code=res.data[i].id;
						this.bankList.push(objc);
					}

				})
			},		
		}
	}
</script>

<style>
	
	
</style>
