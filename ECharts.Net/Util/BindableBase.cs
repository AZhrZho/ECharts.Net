using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ECharts.Net.Util
{
    public abstract class BindableBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string? propertyName = null)
        {
            // 如果新旧值相同，则不执行任何操作
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            // 更新后备字段的值
            backingStore = value;
            // 触发属性变更通知
            OnPropertyChanged(propertyName);
            // 返回 true 表示值已成功更改
            return true;
        }
    }
}
