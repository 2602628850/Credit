<template>
	<view>
		<!-- 首页轮播图 -->
		<swiper
		  indicator-dots
		  indicator-active-color="#FFFFFF"
		  circular
		  autoplay
		>
			<swiper-item
			  v-for="item in rotation"
			  :key="item.id"
			>
				<image :src = "item.url"></image>
			</swiper-item>
		</swiper>
		<!-- 首页轮播图 -->
	</view>
</template>

 
<script>
	export default {
		data() {
			return {
				rotation: [
					{
						id: 1,
						url: '/static/image/lb1.jpg'
					},
					{
						id: 2,
						url: '/static/image/lb2.jpg'
					},
					{
						id: 3,
						url: '/static/image/lb3.jpg'
					},
					{
						id: 4,
						url: '/static/image/lb4.jpg'
					}
				]
			}
		},

	}
</script>
 
<style lang="scss" scoped>
	image{
		margin-left: 3.3%;
		margin-top: 3%;
	    width: 700rpx;
		height: 90%;
	}

</style>