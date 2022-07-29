<template>
	<view class="pagebackground">
		<navigation-bar :title="intereal"></navigation-bar>
		<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">
		<view style="margin-left: 2%;width: 96%;">
			<uni-row v-for="(item,index) in rotation" :key="item" :gutter="20">
				<view v-if="index%2==0">
					<uni-col :span="12" class="unicol" v-on:click="ToDetail()">
						<view style="background-color: white;">
							<text style="display: flex;">
								<image :src="item.url" class="imagewh"></image>
							</text>
							<text style="display: flex;margin-left: 10px;">
								{{item.productName}}
							</text>
							<text style="display: flex;margin-left: 10px;">
								{{$t('interal.shengyu')}}{{item.count}}
							</text>
							<text class="intewh">
								{{item.needCount}}{{$t('interal.interal')}}
							</text>
							<view>&nbsp;</view>
						</view>

					</uni-col>

					<uni-col :span="12" class="unicol" v-if='index+1<rotation.length' v-on:click="ToDetail()">
						<view style="background-color: white;">
							<text style="display: flex;">
								<image :src="rotation[index+1].url" class="imagewh"></image>
							</text>
							<text style="display: flex;margin-left: 10px;">
								{{rotation[index+1].productName}}
							</text>
							<text style="display: flex;margin-left: 10px;">
								{{$t('interal.shengyu')}}{{item.count}}
							</text>
							<text class="intewh">
								{{item.needCount}}{{$t('interal.interal')}}
							</text>
							<view>&nbsp;</view>
						</view>

					</uni-col>
				</view>
			</uni-row>
		</view>

		</app-content-view>
	</view>

</template>

<script>
	export default {
		methods: {
			ToDetail(){
				uni.navigateTo({
					url:"/pages/integral/productDetail"
				})
			}
		},
		created() {
			if (!uni.getStorageSync('token')) {
			uni.reLaunch({
				url:'/pages/login/login'
			})
			return;
			}
		},
		data() {
			return {
				intereal:this.$t('interal.jifendh'),
				rotation: [{
						id: 1,
						url: '../../static/image/inteproduct/1.png',
						productName: 'ไดร์เป่าผม',
						count: '3000+',
						needCount: '400'
					},
					{
						id: 2,
						url: '../../static/image/inteproduct/2.png',
						productName: 'หม้อชาบู',
						count: '3000+',
						needCount: '400'
					},
					{
						id: 3,
						url: '../../static/image/inteproduct/3.png',
						productName: 'หม้อหุงข้าว',
						count: '3000+',
						needCount: '400'
					},
					{
						id: 4,
						url: '../../static/image/inteproduct/4.png',
						productName: 'หมวกกันน็อก',
						count: '3000+',
						needCount: '400'
					},
					{
						id: 5,
						url: '../../static/image/inteproduct/5.png',
						productName: 'ชุดผ้าปูที่นอน',
						count: '3000+',
						needCount: '400'
					},
					{
						id: 6,
						url: '../../static/image/inteproduct/6.png',
						productName: 'ถุงมือ',
						count: '3000+',
						needCount: '400'
					},
					{
						id: 7,
						url: '../../static/image/inteproduct/7.png',
						productName: 'กาต้มน้ำไฟฟ้า',
						count: '3000+',
						needCount: '400'
					}
				]
			}
		},

	}
</script>

<style>
	.demo-uni-col {
		height: 36px;
		border-radius: 3px;
	}

	.dark {
		background-color: #d3dce6;
	}

	.unicol {
		text-align: center;
		margin-top: 20px;
	}

	.imagewh {
		width: 170px;
		height: 170px;
	}

	.intewh {
		text-align: right;
		margin-left: 50%;
		color: #00875a;
		font-weight: 600;
	}
</style>
