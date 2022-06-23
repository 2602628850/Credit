<template>
<!--	修改个人信息-->
	<navigation-bar></navigation-bar>
	<app-content-view :show-navigation-bar="true">

	</app-content-view>
</template>

<script>
	import NavigationBar from "../../components/navigation-bar";
	import AppContentView from "../../components/app-content-view";
	export default {
		name: "change-info",
		components: {AppContentView, NavigationBar}
	}
</script>

<style scoped>

</style>