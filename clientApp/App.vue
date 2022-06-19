<script>
	import interceptor from './common/js/interceptor/interceptor'

	export default {
		onLaunch: function() {
			interceptor()
			console.log('App Launch')
		},
		onShow: function() {
			console.log('App Show')
		},
		onHide: function() {
			console.log('App Hide')
		}
	}
</script>

<style lang="scss">
	/*每个页面公共css */
	@import "/common/css/flex.css";
	@import "/common/css/public.css";
	@import "/static/font/iconfont.css";
	@import "/common/uni.css";

	//uni-app {
	//	box-shadow: 0 -15px 10px rgba(0,0,0, 0.5);
	//}

	uni-page-body {
		width: 100%;
		height: 100%;
	}


	@media screen and (min-width: 960px) {
		uni-app {
			max-width:500px;
			overflow-y: scroll;
			margin:auto;
			box-shadow: 0 0 20px #aaa;
		}
	}

</style>
