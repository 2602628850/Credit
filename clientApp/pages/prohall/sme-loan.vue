<template>
	<navigation-bar :title="$t('semloan.title')"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="true" :show-navigation-bar="false">

		<view>
			<uni-card class="box-card">
				<view>
					<text><span>SME Loans - Week</span></text>
				</view>
				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.UnitPrice')}}</span>
					</uni-col>
					<uni-col :span="4">
						<text style="margin-right: 5px;"><span>${{productObj.price}}</span></text>
					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.Minimum')}}</span>
					</uni-col>
					<uni-col :span="4">
						<text style="text-align: right;"><span>{{productObj.buyMinUnit}}份</span></text>
					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.cycle')}}</span>
					</uni-col>
					<uni-col :span="4">
						<text style="margin-right: 5px;"><span>{{productObj.cycle}}{{$t('financialproduct.daday')}}</span></text>
					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.returnrate')}}</span>
					</uni-col>
					<uni-col :span="4">
						<text style="margin-right: 5px;"><span>{{productObj.dailyRate}}%</span></text>
					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.buymum')}}</span>
					</uni-col>
					<uni-col :span="6">


						<view class="numberBtn">
							<view @click="reduce" class="countBtn reduceBtn"> － </view>
							<view>
								<input type="number" @input="getamount()" v-model="numberinput" class="sumTotal" />
							</view>
							<view @click="add" class="countBtn addBtn"> + </view>
						</view>


					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.buyprice')}}</span>
					</uni-col>
					<uni-col :span="6">
						<text>${{amount}}</text>
					</uni-col>
				</uni-row>
				<view style="margin-top: 15px;font-size: 15px">
					<button class="btn-task" @click="submitProduct()">
						<!---->
						<text class="text-small text-white"><span>{{$t('semloan.button')}}</span></text>
					</button>
				</view>
			</uni-card>

			<uni-card class="box-card">
				<view class="margin-top-xl card-content-secondary">
					<view>
						<text class="text-bold text-lg"><span>{{$t('chaka.Procontent')}}</span></text>
					</view>
					<text class=" margin-top text-sm line-height-16">
							{{productObj.introduction}}
					</text>
				</view>

			</uni-card>
		</view>

	</app-content-view>
</template>

<script>
	export default {
		data() {
			return {
			    price:0,//购买单价	
				amount:0,//购买总金额
				numberinput: '0',//购买份数
				deparam:{},//获取产品对象需要传的参数
				productObj:{},//当前的产品对象
				buyParam:{},//购买需要的参数
			}
		},
		onLoad: function(option) {
			this.deparam.Id=option.id;
			this.getDetail();
			
		},
		methods: {
			reduce() {
				if(this.numberinput-1>=0){
				this.numberinput--
				this.getamount()
				}
			},
			add() {
				this.numberinput++
				this.getamount()
			},
			getDetail(){
				var url="/Product/GetFinancialProduct";
				this.ApiGet(url,this.deparam).then(res => {
					this.productObj = res.data;
					this.price=this.productObj.price
					this.buyParam.ProductId=this.productObj.id;//购买时需要传产品id
				})
			},
			getamount(){
				this.amount=this.numberinput*this.price;
			},
			TitleResult(msg){
				uni.showToast({
					title: msg,
					duration: 3000,
				})
			},
			//购买
			submitProduct(){
				if(this.numberinput.split(" ").join("").length === 0||parseFloat(this.numberinput)<=0){
					var msg=this.$t('financialproduct.inputval');
					this.TitleResult(msg)
					return;
				}
				this.buyParam.UnitCount=this.numberinput;//购买份数
				const url = decodeURI(encodeURI('/Order​/BuyFinancilProduct').replace(/%E2%80%8B/g, ""));
				this.ApiPost(url,this.buyParam).then(res => {
					if(res.data=="add_success"){
						var msg=this.$t('financialproduct.buysuc');
						this.TitleResult(msg)
						uni.navigateTo({
							url: '/pages/prohall/sme'
						})
					}else{
						var msg= res.data;
						this.TitleResult(msg)
					}
				})
			}
			
		}
	}
</script>

<style>
	.btn-task {
		height: 33px;
		line-height: 33px;
		text-align: center;
		border-radius: 10px;
		min-width: 100px;
		color: #fff;
		font-size: 14px;
		background: linear-gradient(270deg, #108d62, #54b78d);
	}

	.button {
		position: relative;
		display: block;
		margin-left: auto;
		margin-right: auto;
		padding-left: 14px;
		padding-right: 14px;
		box-sizing: border-box;
		font-size: 18px;
		text-align: center;
		text-decoration: none;
		line-height: 2.55555556;
		border-radius: 5px;
		-webkit-tap-highlight-color: transparent;
		overflow: hidden;
		color: #000;
		background-color: #f8f8f8;
		cursor: pointer;
	}

	.lines-white {
		color: #fff;
	}

	.text-small {
		font-size: 14px;
	}



	.countBtn {
		color: #10AEFF;
	}

	.reduceBtn {
		border-radius: 10rpx 0rpx 0rpx 10rpx;
		width: 60rpx;
		border: 1rpx solid #ddd;
		border-right: none;
		text-align: center;
	}

	.addBtn {
		border-radius: 0rpx 10rpx 10rpx 0rpx;
		width: 60rpx;
		border: 1rpx solid #ddd;
		border-left: none;
		text-align: center;
	}

	.sumTotal {
		border: 1rpx solid #ddd;
		width: 100rpx;
		text-align: center;
	}

	.numberBtn {
		position: absolute;
		right: 0%;
		width: auto;
	}



	.numberBtn view {
		/* border: 1rpx solid #ddd; */
		float: left;
		/* width: 80rpx; */
	}
</style>
