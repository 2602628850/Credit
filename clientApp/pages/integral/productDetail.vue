<template>
	<view class="pagebackground">
		<navigation-bar :title="rotation.productName"></navigation-bar>
		<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">
		<view style="margin-left: 1%;width: 98%;background-color: white;">
			<text>
				<image :src="rotation.url" style="width: 96%;height: 200px;margin-left: 2%;margin-top: 5%;"></image>
			</text>
			<text style="display: flex;margin-left: 10px;">
				{{rotation.productName}}
			</text>
			<text style="display: flex;margin-left: 10px;">
				{{$t('interal.shengyu')}}{{rotation.count}}
			</text>
			<text class="intewh">
				{{rotation.needCount}}{{$t('interal.interal')}}
			</text>
		  <text v-html="rotation.description"></text> 
		 <button type="primary" style="background-color: #00875a;margin-top: 3%;">{{$t('interal.lijiduihuan')}}</button>
		 <view>&nbsp;</view>
		</view>
		</app-content-view>
	</view>
</template>

<script>
	export default {
		methods: {},
		mounted() {
			if (!uni.getStorageSync('token')) {
			uni.reLaunch({
				url:'/pages/login/login'
			})
			}
		},
		data() {
			return {
				rotation: {
					id: 1,
					url: '../../static/image/inteproduct/1.png',
					productName: 'ไดร์เป่าผม',
					count: '3000+',
					needCount: '400',
					description:'<p>Product Description</p><p><br></p><p>OTTO เตาย่างไร้ควัน GR-141 เตาย่างไฟฟ้า ปิ้ง ย่าง ไร้ควัน เตาไฟฟ้า เตาย่าง เตาปิ้งบาร์บีคิว ย่างอาหารทะเล ซีฟู๊ด</p><p>-ถาดกว้างขนาด(มม.) : 380<br>-กำลังไฟฟ้า(วัตต์) : 2000<br>-ขนาด 48.6x10.0x35.<br>-ฟังก์ชั่นการทำงาน:ปิ้งย่างอาหาร<br>-ปรับความร้อนได้(ระดับ) : 5<br>-ตะแกรงย่างทำจากสแตนเลสอย่างดี มีเทอร์โมสตัทควบคุมความร้อน<br>-อื่นๆ : ตะแกรงย่างปรับความสูงได้ 3 ระดับ<br></p>'
				}
			}
		},

	}
</script>


<style>
	.intewh {
		text-align: right;
		margin-left: 73%;
		color: #00875a;
		font-weight: 600;
	}
</style>
