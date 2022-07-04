<template>
	<view class="pagebackground">
		<navigation-bar :title="intereal"></navigation-bar>
		<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">


			<view style="margin-top: 20px;">
				<uni-card class="box-card" style="padding: 0;">
					<uni-row :gutter="20" v-on:click="ToShop()" style="height: 60px;">
						<uni-col :span="3">
							<image src="/static/image/static/bdjl.jpg" style="width: 30px;height: 30px;"></image>
						</uni-col>
						<uni-col :span="21">
							<view style="font-size: 16px; opacity: 1;font-weight: bold;">
								{{$t('monchange.cz')}}
							</view>
							<view style="font-size: 8px"><span>{{ $t('monchange.banlance') }}:$1000.00</span></view>
							<view style="font-size: 8px"><span>{{totime }}</span></view>
							<view style="margin-top:10px;text-align: right;margin-top: -15%;">

								<text class="g-icons">+$1000</text>
							</view>
						</uni-col>
					</uni-row>
					<uni-row :gutter="20" style="height: 50px;margin-top: 10%;">
						<uni-col :span="3">
							<image src="/static/image/static/bdjl.jpg" style="width: 30px;height: 30px;"></image>
						</uni-col>
						<uni-col :span="21">
							<view style="font-size: 16px; opacity: 1;font-weight: bold;">
								{{$t('monchange.cz')}}
							</view>
							<view style="font-size: 8px"><span>{{ $t('monchange.banlance') }}:$1000.00</span></view>
							<view style="font-size: 8px"><span>{{totime }}</span></view>
							<view style="margin-top:10px;text-align: right;margin-top: -15%;">

								<text class="g-icons">+$1000</text>
							</view>
						</uni-col>
					</uni-row>
					<view style="margin-bottom: 10px;">&nbsp;</view>
				</uni-card>

			</view>


		</app-content-view>
	</view>

</template>
<script>
	export default {
		data() {
			return {
				intereal: this.$t('monchange.jebd'),
				totime: ''
			}
		},

		mounted() {
			if (!uni.getStorageSync('token')) {
				uni.reLaunch({
					url: '/pages/login/login'
				})
			}

			if (this.$t('monchange.sj') == "0") {
				this.totime = this.formatDateCh(1527488790000) //中文时间

			} else {
				this.totime = this.formatDate(1527488790000) //英文时间
			}
		},
		methods: {
			//将毫秒的时间转换成美式英语的时间格式,eg:3rd May 2018
			formatDate(millinSeconds) {
				var date = new Date(millinSeconds);
				var monthArr = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Spt", "Oct", "Nov",
					"Dec");
				var suffix = new Array("st", "nd", "rd", "th");

				var year = date.getFullYear(); //年
				var month = monthArr[date.getMonth()]; //月
				var ddate = date.getDate(); //日

				if (ddate % 10 < 1 || ddate % 10 > 3) {
					ddate = ddate + suffix[3];
				} else if (ddate % 10 == 1) {
					ddate = ddate + suffix[0];
				} else if (ddate % 10 == 2) {
					ddate = ddate + suffix[1];
				} else {
					ddate = ddate + suffix[2];
				}
				var dt = date.getHours() + " : " + date.getMinutes();
				return ddate + " " + month + " " + year + " " + dt;
			},
			formatDateCh(millinSeconds) {
				var date = new Date(millinSeconds);
				var year = date.getFullYear(); //年
				var month = date.getMonth(); //月
				var ddate = date.getDate(); //日
				var sh = date.getHours(); //时
				var mi = date.getMinutes();
				return year + "-" + month + " " + ddate + " " + sh + ":" + mi;
			}
		},
	}
</script>


<style>

</style>
