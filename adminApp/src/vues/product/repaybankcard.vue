<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input">
			<div>还款名称</div>
			<el-input v-model="levelName"></el-input>
		</el-space>
		<el-space class="search-input400">
			<div>还款类型：</div>
				<el-select v-model="repayTypes" class="in-input" size="large" placeholder="选择类型" >
        <el-option
      key=""
      label="请选择"
      value="请选择"
    />
				<el-option
      v-for="item in repayTypedata"
      :key="item.repayType"
      :label="item.repayTypeName"
      :value="item.repayType"
        />
         </el-select> 
		</el-space>
	</el-space>
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary" @click="loadData(1)">查询</el-button>
		<el-button type="primary" @click="addItem">添加</el-button>
	</div>
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="bankName" label="银行名称" width="200" align="center"></el-table-column>
		
		<el-table-column prop="levelName" label="等级名称" width="150" align="center"></el-table-column>
		<el-table-column prop="cardNo" label="绑定卡号" width="200" align="center"></el-table-column>
		<el-table-column prop="bindUser" label="绑定用户" width="120" align="center"></el-table-column>
		<el-table-column prop="amount" label="还款金额" width="120" align="center"></el-table-column>
		<el-table-column prop="isEnable" label="是否启用" width="100" align="center">
			<template #default="scope">
				{{ scope.row.isEnable=="1"?"启用":"禁用"}}
			</template>
		</el-table-column>
    <el-table-column prop="" label="操作" align="center" width="200" fixed="right">
			<template #default="scope">
				<el-space>
					<el-button type="danger" size="small" plain @click="upXJ(scope.row)" v-if="scope.row.isEnable==1">禁用</el-button>
					<el-button type="primary" size="small" plain @click="upQY(scope.row)" v-else>启用</el-button>
					<el-button type="primary" size="small" plain @click="updItem(scope.row)">修改</el-button>
				
					<el-button type="danger" v-show="isChooseDel==0" size="small" plain @click="delItem(scope.row,1)">删除</el-button>
					<el-button type="danger" v-show="isChooseDel==1"  size="small" plain @click="delItem(scope.row,0)">删除</el-button>
				</el-space>
			</template>
		</el-table-column>
	</el-table>
	<!--	</div>-->
	<div class="w100 flex-row-end mgt" id="page">
		<el-pagination background layout="prev, pager, next" @current-change="currentPage" :total="total" :page-size="pageSize"/>
	</div>


	<el-dialog v-model="windowStatus" v-loading="windowSaving" width="600px">
		<el-space direction="vertical">
			<el-space>
				<div class="in-title">绑定类型：</div>
				<el-select v-model="editItem.repayType" class="in-input" size="large" placeholder="选择类型" >
				<el-option
      key=""
      label="请选择"
      value="请选择"
    />	<el-option
      v-for="item in repayTypedata"
      :key="item.repayType"
      :label="item.repayTypeName"
      :value="item.repayType"
        @click="getrepayLevel(item.repayType)"/>
         </el-select>
			</el-space>
			<el-space>
				<div class="in-title">绑定产品：</div>
				<el-select v-model="editItem.repayLevelId" class="in-input" size="large" placeholder="选择产品" >
					<el-option
      key=""
      label="请选择"
      value="请选择"
    /><el-option
      v-for="item in repayLeveldata"
      :key="item.id"
      :label="item.levelName"
      :value="item.id"
        />
         </el-select>
			</el-space>
			<el-space>
				<div class="in-title">绑定银行：</div>
				<el-select v-model="editItem.bankId" class="in-input" size="large" placeholder="选择产品" >
					<el-option
      key=""
      label="请选择"
      value="请选择"
    /><el-option
      v-for="item in bankdata"
      :key="item.bankId"
      :label="item.bankName"
      :value="item.bankId"
        />
         </el-select>
			</el-space>
			<el-space>
				<div class="in-title">卡号</div>
				<el-input class="in-input" v-model="editItem.cardNo"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">绑定用户：</div>
				<el-input class="in-input" v-model="editItem.bindUser"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">还款金额：</div>
				<el-input class="in-input" v-model="editItem.amount"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">是否启用：</div>
			<el-radio-group v-model="editItem.isEnable"  class="in-input">
        <el-radio label="1" >启用</el-radio>
        <el-radio label="0" >禁用</el-radio>
      </el-radio-group>
			</el-space>
			<el-space>
				<el-button type="primary" @click="saveItem">保存</el-button>
			</el-space>
		</el-space>
	</el-dialog>
</template>

<script>
	export default {
		name: "repay-manager",
		beforeRouteEnter(to, from, next) {
			next(vm => {
				vm.getTableHeight();
				vm.loadData(1)
			})
		},
		data() {
			return {
					isChooseDel:0,
			uploadUrl: 'http://localhost:8003/v1/Upload/Image',
				levelName: '',
				repayTypes:'',
				contentHeight: '0px',
				pageIndex: 1,
				pageSize: 20,
				total: 0,
				tableData: [],
				repayLeveldata: [],
				bankdata: [],
        repayTypedata :[{repayType:0,repayTypeName:'信用卡还款'},{repayType:10,repayTypeName:'贷款还款'}],//还款类型下啦选项
				loading: false,
				windowStatus: false,
				editItem: {isEnable:"0"},
				windowSaving: false,
			}
		},
	components: {
  },
    created(){
      this.$Http.get('AdminBank/GetBankList').then(res => {
				this.bankdata=res.data.data;
			})
    },
		methods: {
				currentPage(pageindex){
          this.loadData(pageindex)
				},
			delItem(item,indexcho) {
				const ids=[];
				ids.push(item.id);
				this.$msgbox({
					title: '提示',
					message: '确认删除' + item.levelName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminRepay/RepayBankCardDelete', {ids: ids}).then(() => {
								this.loadData();
								done();
								this.isChooseDel=indexcho;
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
			upQY(item) {
				const ids=[];
				ids.push(item.id);
				this.$msgbox({
					title: '提示',
					message: '确认启用' + item.levelName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminRepay/RepayBankCardEnable', {ids: ids}).then(() => {
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
			upXJ(item) {
				const ids=[];
				ids.push(item.id);
				this.$msgbox({
					title: '提示',
					message: '确认禁用' + item.levelName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminRepay/RepayBankCardDisable', {ids: ids}).then(() => {
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
			getrepayLevel(item) {
				let param = {};
				param.repayType = item;
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.$Http.get('AdminRepay/GetRepayLevelPagedList', {params: param}).then(res => {
					this.repayLeveldata = res.data.data.items; 
				})
			},
			saveItem() {
				if (!this.editItem.cardNo) {
					this.$message.error('请输入卡号');
					return;
				}
				if (this.$ObjectUtil.isEmpty(this.editItem.isEnable)) {
					this.$message.error('请选择是否启用');
					return;
				}
				this.windowSaving = true;
				if (this.editItem.id) {
					this.$Http.post('AdminRepay/RepayBankCardUpdate', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				} else {
					this.$Http.post('AdminRepay/RepayBankCardCreate', this.editItem).then(() => {
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
				if (this.levelName) {
					param.levelName = this.levelName;
				}
				if (this.repayTypes!=''||this.repayTypes!=null) {
					param.repayType = this.repayTypes;
				}
				if (page) {
					this.pageIndex = page-1;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
				this.$Http.get('AdminRepay/GetRepayBankCardPagedList', {params: param}).then(res => {
				
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