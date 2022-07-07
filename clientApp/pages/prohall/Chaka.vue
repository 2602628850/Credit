<template>
	<navigation-bar :title="$t('chaka.title')"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">
		<view>
			<view class="page">
				<view class="card-page-place"></view>
				<view class="page-card">
					<view class="card-page margin-top">
						<view class="credit-card position-relative">
							<image class="card-bg position-absolute" src="/static/image/hall/product-info-credit.png">
							</image>
							<view class="credit-info position-relative flex-1 justify-between">
								<view class="flex-row justify-between">
									<view>
										<text class="text-white text-lg text-bold">
											<span>CREDIT</span></text>
									</view>
									<view >
										<text class="font-italic text-bold text-white">
											{{lv.levelName}}</text>
									</view>
								</view>
								<view>
									<text class="card-num">**** {{this.cardNo}}
											****</text>
								</view>
								<view class="flex-row justify-between">
									<view>
										<text class="text-white text-xs">{{$t('chaka.bankname')}}
										</text>
										<text class="text-white text-small text-bold">
											{{this.bankName}}</text>
									</view>
									<view class="align-flex-end">
										<text class="text-white text-xs">{{$t('chaka.repayment')}}</text>
										<text class="credit-amount text-small text-bold">
											<!-- <span>$17.60</span></text> -->
											{{this.amount}}
										</text>
									</view>
									<!---->
								</view>
							</view>
						</view>
						<view class="margin-top-lg">
							<view>
								<view class="flex-row align-center flex-1">
									<text class="text-small"><span>{{$t('chaka.todayCheckNum')}}:</span>
									</text>
									<text class="text-small text-bold text-primary margin-left-xs"><span>3</span>
									</text>
								</view>
								<view class="margin-top">
									<button class="btn-search" style="width: 100%;" @click="GetChData()">{{$t('chaka.checkButton')}}</button>
								</view>
							</view>
						</view>
						
						<!--卡号-->
						<view id="cardList" class="margin-top-lg card-content-secondary">
							<view>
								<text class="text-bold text-lg"><span>{{$t('chaka.selectrepayment')}}</span></text>
							</view>
								<!--循环卡号-->
							<view class="card-content-sm flex-row align-center margin-top" v-for="(item,index) in cardlist" :key="index"  :class="{'card-select':index==current}" @click="UpdateVal(index,item.cardNo,item.bankName,item.amount,item.id)">
								<view class="flex-1">
									<text class="text-sm"><span>{{item.bindUser}}</span></text>
									<text class="text-xs text-secondary">
										<span>****{{item.cardNo}}****</span></text>
								</view>
								<text class="text-lg"><span>${{item.amount}}</span></text>
							</view>
						
						</view>
						
						
						<!---->
						<view class="margin-top-lg card-content-secondary">
							<view>
								<text class="text-bold text-lg"><span>{{$t('chaka.repayment')}}</span></text>
							</view>
							<view class="align-center margin-top-sm">
								<text class="text-21"><span>${{this.amount}}</span></text>
							</view>
							<view class="flex-row margin-top">
								<button class="flex-1 btn-primary" @click="rePay()">{{$t('chaka.behalfButton')}}</button>
							</view>
						</view>
						<view class="margin-top-xl card-content-secondary">
							<view>
								<text class="text-bold text-lg"><span>{{$t('chaka.todayCheck')}}</span>
								</text>
								<!---->
							</view>
							<view class="flex-row margin-top">
								<view class="flex-1">
									<text class="text-bold text-primary text-21">
										<span>0</span></text>
									<text class="text-xs text-secondary margin-top-xs">
										<span>{{$t('chaka.Tocheck')}}</span></text>
								</view>
								<view class="flex-1">
									<text class="text-bold text-primary text-21">
										<span>$0</span></text>
									<text class="text-xs text-secondary margin-top-xs">
										<span>{{$t('chaka.Tocheckprofit')}}</span></text>
								</view>
							</view>
						</view>
						<view class="margin-top-xl card-content-secondary">
							<text class="text-bold text-lg"><span>{{$t('chaka.Procontent')}}</span></text>
							<text class=" margin-top text-sm line-height-16">
								{{this.leaveobj.introduction}}
							</text>
						</view>
					</view>
					<view class="margin"></view>
				</view>
				<view>
					<!---->
				</view>
			</view>
		</view>

	</app-content-view>
</template>

<script>
	export default {
		data() {
			return {
               lv:{}, //等级id
			   cardlist:{},//卡号集合
			   current:0,//当前选中银行卡序号
			   cardNo:'**** ****',//卡号
			   bankName:'****',//银行名称
			   amount:0,//还款金额
			   leaveobj:{},//还款等级对象
			   repayObj:{},//还款对象
			   PayeeBankCardId:0,//银行卡id
			}
		},
		mounted() {
			this.GetRepayLevel();
		},
		onLoad: function(option) {
			this.lv.Leaveid=option.id;
			this.lv.levelName=option.levelName;
		},
		methods: {
			//因为等级介绍内容可能很长,所以不建议通过url传过来
			GetRepayLevel(){
				var url = "/Repay/GetRepayLevel";
				this.ApiGet(url,this.lv).then(res => {
					this.leaveobj = res.data
					
				})
			},
			GetChData() {//获取页面基础数据
				var url = "/Repay/GetRepayBankCardList";
				this.ApiGet(url,this.lv).then(res => {
					this.cardlist = res.data
					this.cardNo=res.data[0].cardNo;
					this.bankName=res.data[0].bankName;
					this.amount=res.data[0].amount;
					//还款对象
					this.repayObj.Type="bankcard";//线下还款
					this.repayObj.PayeeBankCardId=res.data[0].id;//银行卡id
					this.repayObj.SourceType=300;//代理还款申请
					this.repayObj.Amount=this.amount;//还款金额
					
					
				})
			},
			//点击银行卡的时候页面数据动态变化
			UpdateVal(index,cardNo,bankName,amount,id){
				this.current=index;
				this.cardNo=cardNo;
				this.bankName=bankName;
				this.amount=amount;
				//还款对象
				this.repayObj.Type="bankcard";//线下还款
				this.repayObj.PayeeBankCardId=id;//银行卡id
				this.repayObj.SourceType=300;//还款申请
				this.repayObj.Amount=this.amount;//还款金额
			},
			//还款
			rePay(){
				var url = "/Repay/RepayApplication";
				this.ApiPost(url,this.repayObj).then(res => {
					if(res.data=="repay_success"){
						uni.showToast({
							title: "还款成功",
							duration: 3000,
						})
						uni.navigateTo({
							url: '/pages/prohall/creditIndex'
						})
					}else{
						uni.showToast({
							title: "还款失败!",
							duration: 3000,
						})
					}
				})
			}
		}
	}
</script>

<style>
	.page {
		position: relative;
	}

	view {
		display: flex;
		flex-direction: column;
	}

	view {
		font-size: 15px;
		overflow-wrap: anywhere;
	}

	.card-page-place {
		position: absolute;
		height: 300px;
		left: 0;
		right: 0;
		top: 0;
		background-color: #f4f5f7;
	}

	.page-card {
		background-color: #fff;
		margin-top: 15px;
		border-top-left-radius: 30px;
		border-top-right-radius: 30px;
		position: relative;
	}

	.card-page {
		padding: 0 19px;
	}

	.margin-top {
		margin-top: 15px;
	}

	.credit-card {
		height: 265px;
	}

	.position-relative {
		position: relative !important;
	}

	.card-bg {
		width: 457px;
		height: 265px;
		top: 0;
		left: 0;
	}

	.position-absolute {
		position: absolute !important;
	}

	.credit-info {
		padding: 25px 20px;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	.position-relative {
		position: relative !important;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	* {
		margin: 0;
		-webkit-tap-highlight-color: transparent;
	}

	.level-icon {
		width: 30px;
		height: 30px;
		line-height: 30px;
		text-align: center;
		border-radius: 30px;
		border: 1px solid #98d4af;
	}

	.font-italic {
		font-style: italic;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.card-num {
		letter-spacing: 2px;
		font-size: 20px;
		color: #fff;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-xs {
		font-size: 12px;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-small {
		font-size: 14px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.margin-top-lg {
		margin-top: 20px;
	}

	view {
		display: flex;
		flex-direction: column;
	}

	.align-center {
		align-items: center !important;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-small {
		font-size: 14px;
	}

	.text-primary {
		color: #00875a;
	}

	.text-small {
		font-size: 14px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.margin-left-xs {
		margin-left: 6px;
	}

	.margin-top {
		margin-top: 15px;
	}

	.btn-search {
		background: linear-gradient(270deg, #54b78d, #85d49d);
		height: 44px;
		line-height: 44px;
		text-align: center;
		font-size: 14px;
		font-weight: 700;
		color: #fff;
		padding: 0 20px;
		border-radius: 15px;
	}

	.card-content-secondary {
		border-radius: 15px;
		background-color: #f4f5f7;
		padding: 20px;
	}

	.margin-top-xl {
		margin-top: 25px;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	image>img {
		-webkit-user-select: none;
		display: block;
		position: absolute;
		top: 0;
		left: 0;
		opacity: 0;
	}

	image>div,
	image>img {
		width: 100%;
		height: 100%;
	}

	.card-content-secondary {
		border-radius: 15px;
		background-color: #f4f5f7;
		padding: 20px;
	}

	.margin-top-lg {
		margin-top: 20px;
	}

	.card-content-sm {
		border-radius: 15px;
		background-color: #fff;
		padding: 15px;
	}

	.margin-top {
		margin-top: 15px;
	}

	.align-center {
		align-items: center !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.card-select {
		border: 1px solid #00875a;
	}

	.card-content-secondary {
		border-radius: 15px;
		background-color: #f4f5f7;
		padding: 20px;
	}

	.margin-top-lg {
		margin-top: 20px;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.text-21 {
		font-size: 21px;
	}

	.text-xxs {
		font-size: 11px;
	}

	.margin-top-xs {
		margin-top: 5px;
	}

	.btn-primary {
		background-color: #00875a;
		border: 1px solid #00875a !important;
		color: #fff !important;
		border-radius: 15px;
		font-size: 15px;
		height: 44px;
		line-height: 44px;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	button {
		position: relative;
		display: block;
		margin-left: auto;
		margin-right: auto;
		padding-left: 14px;
		padding-right: 14px;
		box-sizing: border-box;
		text-align: center;
		text-decoration: none;
		-webkit-tap-highlight-color: transparent;
		overflow: hidden;
		cursor: pointer;
	}

	.credit-amount {
		color: #fdd741;
	}
</style>
