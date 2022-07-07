<template>
	<navigation-bar :title="$t('recharge.title')"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="true" :show-navigation-bar="false">
	<view style="width: 80%;padding: 8%;">
		<view class="viewcontent" v-for="(item,index) in dataitem" :key="index" :class="{'view-select':index==current}"
			@click="UpdateView(index,item.count)">
			<text class="centerview" :class="{'view-select':index==current}">${{item.count}}</text>
		</view>

		<view style="margin-top: 20px;text-align: center;margin-left: 7%;">
			<view @click="reduce" class="countBtn reduceBtn" style="float: left;"> － </view>
		    <input type="number" v-model="numberinput" class="sumTotal" style="width: 70%;float: left;" />
			<view @click="add" class="countBtn addBtn"  style="float: left;"> + </view>
		</view>
		<view>&nbsp;</view>
		<view style="margin-top: 20px;">
			<button style="margin-top: 10%;" @click="reCharge()" class="view-select">{{$t('recharge.suresubmit')}}</button>
		</view>
	</view>
	<view>
		<text style="display: flex;font-weight: 800;">{{$t('recharge.remark')}}</text>
		<text style="display: flex;margin-top: 10px;">
			{{$t('recharge.remark1')}}
		</text>
		<text style="display: flex;">
			{{$t('recharge.remark2')}}
		</text>
		<text style="display: flex;">
				{{$t('recharge.remark3')}}
		</text>
		<text style="display: flex;">
				{{$t('recharge.remark4')}}
		</text>
		<text style="display: flex;">
				{{$t('recharge.remark5')}}
		</text>
		<text>
				{{$t('recharge.remark6')}}
		</text>
	</view>
	</app-content-view>
</template>

<script>
	export default {
		data() {
			return {
				current: 0,
				numberinput: '',
				rechargeObj:{},//充值对象
				dataitem: [{
					count: 500
				}, {
					count: 1000
				}, {
					count: 3000
				}, {
					count: 5000
				}, {
					count: 10000
				}, {
					count: 50000
				}]
			}
		},
		mounted(){
			this.numberinput=this.dataitem[0].count;
			//要提交的数据
			this.rechargeObj.Amount=this.numberinput;
			this.rechargeObj.Type="bankcard";//线下支付
			this.rechargeObj.PaymentInfoId=0;//三方支付默认为0
		},
		methods: {
			UpdateView(index,count) {
				this.current = index;
				this.numberinput=count;
				//要提交的数据
				this.rechargeObj.Amount=this.numberinput;
				this.rechargeObj.Type="bankcard";//线下支付
				this.rechargeObj.PaymentInfoId=0;//三方支付默认为0
			},
			//充值
			reCharge(){
				if(this.numberinput.split(" ").join("").length === 0||parseFloat(this.numberinput)<=0){
					var msg=this.$t('recharge.rechnull');
					this.TitleResult(msg)
					return;
				}
				this.rechargeObj.Amount=this.numberinput;
				var url = "/User/UserRecharge";
				this.ApiPost(url,this.rechargeObj).then(res => {
					if(res.data=="recharge_success"){
						var msg=this.$t('recharge.ressuc');
						this.TitleResult(msg)
						uni.navigateTo({
							url: '/pages/index/indexPage'
						})
					}else{
						
						var msg=res.data;
						this.TitleResult(msg)
					}
				})
			},
			reduce() {
				if (parseFloat(this.numberinput) - 100 >= 0) {
					this.numberinput=parseFloat(this.numberinput)-100;
				}
			},
			add() {
				this.numberinput=parseFloat(this.numberinput)+100;
			},
			TitleResult(msg){
				uni.showToast({
					title: msg,
					duration: 3000,
				})
			}
			
		}
	}
</script>

<style>
	.centerview {
		line-height: 40px;
		text-align: center;
	}

	.viewcontent {
		margin-top: 3%;
		border: 1px solid darkgray;
		border-radius: 9px;
		text-align: center;
		height: 40px;
		background-color: rgb(229, 229, 229);
	}

	.view-select {
		background-color: #00875a;
		color: white;
	}

	.reduceBtn {
		border-radius: 10rpx 0rpx 0rpx 10rpx;
		width: 60rpx;
		border: 1rpx solid #ddd;
		border-right: none;
		text-align: center;
		height: 35px;
		line-height: 30px;
	}

	.addBtn {
		border-radius: 0rpx 10rpx 10rpx 0rpx;
		width: 60rpx;
		border: 1rpx solid #ddd;
		border-left: none;
		text-align: center;
		height: 35px;
		line-height: 30px;
	}

	.sumTotal {
		border: 1rpx solid #ddd;
		width: 100rpx;
		text-align: center;
		height: 35px;
		right: 0px;
	}

	.numberBtn {
		right: 0%;
		width: auto;
	}



	.numberBtn view {
		/* float: left; */
	}
</style>
