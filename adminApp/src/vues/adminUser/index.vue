<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input">
			<div>登录账号</div>
			<el-input v-model="username"></el-input>
		</el-space>
	</el-space>
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary" @click="loadData(1)">查询</el-button>
		<el-button type="primary" @click="addItem">添加</el-button>
	</div>
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="username" label="登录账号" width="500" align="center"></el-table-column>
		
		<el-table-column prop="nickname" label="昵称" width="500" align="center"></el-table-column> 
    <el-table-column prop="" label="操作" align="center" width="200" fixed='right'>
			<template #default="scope">
				<el-space> 
					<el-button type="primary" size="small" plain @click="updItem(scope.row)">修改</el-button>
					<el-button type="danger" size="small" plain @click="delItem(scope.row)">删除</el-button>
				</el-space>
			</template>
		</el-table-column>
	</el-table>
	<!--	</div>-->
	<div class="w100 flex-row-end mgt" id="page">
		<el-pagination background layout="prev, pager, next" :total="total" :page-size="pageSize"/>
	</div>


	<el-dialog v-model="windowStatus" v-loading="windowSaving" width="600px">
		<el-space direction="vertical">
			<el-space>
				<div class="in-title">登录名称：</div>
				<el-input class="in-input" v-model="editItem.username"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">昵称：</div>
				<el-input class="in-input" v-model="editItem.nickname"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">管理员密码：</div>
				<el-input class="in-input" v-model="editItem.password"></el-input>
			</el-space>
			<el-space>
				<el-button type="primary" @click="saveItem">保存</el-button>
			</el-space>
		</el-space>
	</el-dialog>
</template>

<script>
	export default {
		name: "adminuser-manager",
		beforeRouteEnter(to, from, next) {
			next(vm => {
				vm.getTableHeight();
				vm.loadData(1)
			})
		},
		data() {
			return {
				username: '',
				contentHeight: '0px',
				pageIndex: 1,
				pageSize: 20,
				total: 0,
				tableData: [],
				loading: false,
				windowStatus: false,
				editItem: {isEnable:"0",coverImage:''},
				windowSaving: false,
				coverImage:'',
			}
		},
	components: {
  },
		methods: {
			delItem(item) {
				this.$msgbox({
					title: '提示',
					message: '确认删除' + item.username + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminUser/AdminUserDelete', {id: item.id}).then(() => {
								this.loadData();
								done();
							}).catch(res => {
								this.$message.error(res.data.message);
								this.loading = false;
							})
						} else {
							done();
						}
					}
				})

			}, 
			saveItem() {
				if (!this.editItem.username) {
					this.$message.error('请输入产品名称');
					return;
				}
				this.windowSaving = true;
				if (this.editItem.id) {
					this.$Http.post('AdminUser/UpdateAdminUser', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				} else {
					this.$Http.post('AdminUser/CreateAdminUser', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				}

			},
			addItem() {
				this.editItem = {};
				this.windowStatus = true;
				this.windowSaving = false;
        this.editItem.isEnable ='1';
			},
			updItem(item) {
				setTimeout(()=>{
					this.$refs.child.updateUrl(item.coverImage)
				},10)
			
				this.windowStatus = true;
				this.windowSaving = false;
				this.editItem = JSON.parse(JSON.stringify(item));
        this.editItem.isEnable =''+ item.isEnable+'';
				
			},
			getTime(time) {
				return this.$DateUtil.formatUnix(time / 1000);
			},
			getTableHeight() {
				this.$nextTick(() => {
					let searchInfo = document.getElementById('search-info');
					let searchButton = document.getElementById('search-button');
					let page = document.getElementById('page');

					let height = searchInfo.offsetHeight + searchButton.offsetHeight + page.offsetHeight + 24 + 'px';

					this.contentHeight = 'calc(100% - ' + height + ')'
				})
			},

			loadData(page) {
			
				let param = {};
				if (this.username) {
					param.username = this.username;
				}
				if (page) {
					this.pageIndex = page-1;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
				this.$Http.get('AdminUser/GetAdminUserPagedList', {params: param}).then(res => {
				
					this.tableData = res.data.data.items;
					this.total = parseInt(res.data.data.totalCount);
					this.loading = false;
				}).catch((res) => {
					this.$message.error(res.data.data.message);
					this.loading = false;
				})
			}
		}
	}
</script>

<style scoped>
	@import "/src/commcss/flex.css";
	@import "/src/commcss/background.css";

</style>