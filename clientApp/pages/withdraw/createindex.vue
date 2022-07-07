<template>
	<navigation-bar title="银行卡提款申请"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="true" :show-navigation-bar="false">
		<view style="margin-top: 6%;margin-left: 3%; font-weight: 600;font-size: 16px;">
			<text>当前余额</text>
		</view>
		<view style="font-weight: 800;font-size: 20px;margin-top: 2%;margin-left: 3%;color:rgb(0, 135, 90);">
			<text>${{userinfo.balance}}</text>
		</view>
		<view style="margin-top: 6%;margin-left: 3%; font-weight: 600;font-size: 16px;">
			<text>提现金额</text>
		</view>
		<view style="width: 110%;margin-left: -5%;">
		<register-input-item style="margin-top: 20px">
			<template v-slot:default>
				<input placeholder="输入提款金额, 最低$20" v-model="numberinput" class="input"/>
			</template>
		</register-input-item>
		</view>
		
		<!--卡号-->
		<view class="margin-top-lg card-content-secondary" >
			<view>
				<text class="text-bold text-lg">请您选择银行卡</text>
			</view>
				<!--循环卡号-->
			<view class="card-content-sm flex-row align-center margin-top" v-for="(item,index) in cardlist" :key="index"  :class="{'card-select':index==current}" @click="UpdateVal(index,item.id)">
				<view class="flex-1">
					<text class="text-sm" style="display: flex;">{{item.bankBranch}}</text>
					<text class="text-xs text-secondary">
						{{item.cardNoText}}</text>
				</view>
			</view>
		
		</view>
		
		
		<view style="margin-top: 20px;">
			<button class="view-select" @click="withOut()">提现</button>
		</view>
		
	</app-content-view>
</template>

<script>
	import RegisterInputItem from "../register/register-input-item.vue";
	export default {
		components: {
			RegisterInputItem
		},
		data() {
			return {
				numberinput: 0,
				userinfo: {},//用户对象
				withoutObj:{},//提款对象
			    cardlist:{},//用户卡号集合
				current:0,//当前选中银行卡序号
			}
		},
		onLoad(){
			this.getCardlist();
		},
		mounted() {
            this.getBalance();
			
			
			//要提交的数据
			this.withoutObj.Amount=this.numberinput;
			this.withoutObj.Type="bankcard";//线下支付
			this.withoutObj.PaymentInfoId=0;//三方支付默认为0
			
		},
		methods: {
			//获取用户余额
			getBalance() {
				var url = "/User/GetUserInfo";
				this.ApiGet(url).then(res => {
					this.userinfo = res.data
				})
			},
			//用户提款
			withOut(){
				this.withoutObj.Amount=this.numberinput;
				var url = "/User/UserWithdrawal";
				this.ApiPost(url,this.withoutObj).then(res => {
					if(res.data=="without_success"){
						uni.showToast({
							title:this.$t('without.withsuc'),
							duration: 3000,
						})
						uni.navigateTo({
							url: '/pages/index/indexPage'
						})
					}else{
						uni.showToast({
							title: this.$t('without.withfail'),
							duration: 3000,
						})
					}
				})
			},
			getCardlist(){
				var url = "/User/GetUserBindCardList";
				this.ApiGet(url).then(res => {
					this.cardlist = res.data
					this.withoutObj.PayeeBankCardId=this.cardlist[0].id;
					
				})
			},
			UpdateVal(index,id){
				this.current=index;
				this.withoutObj.PayeeBankCardId=id;
			}



		}
	}
</script>

<style>
	.view-select {
		background-color: #00875a;
		color: white;
		width: 90%;
	}
	.card-content-secondary {
		border-radius: 15px;
		background-color: #f4f5f7;
		padding: 20px;
	}
	.margin-top-lg {
		margin-top: 20px;
	}
	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}
	.text-lg {
		font-size: 16px;
	}
	.card-content-sm {
		border-radius: 15px;
		background-color: #fff;
		padding: 15px;
	}
	.flex-row {
		flex-direction: row !important;
	}
	.align-center {
		align-items: center !important;
	}
	.margin-top {
		margin-top: 15px;
	}
	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}
	.text-small {
		font-size: 14px;
	}
	.text-xs {
		font-size: 12px;
	}
	.card-select {
		border: 1px solid #00875a;
	}
</style>
